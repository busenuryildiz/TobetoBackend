using AutoMapper;
using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Surveys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concretes;
using Business.Abstracts;
using Business.DTOs.Request.SurveyQuestion;



public class SurveyManager : ISurveyService
{
    private readonly ISurveyDal _surveyDal;
    private readonly ISurveyQuestionService ?_surveyQuestionService;
    private readonly IMapper _mapper;

    public SurveyManager(ISurveyDal surveyDal, IMapper mapper, ISurveyQuestionService  surveyQuestionService  )
    {
        _surveyDal = surveyDal;
        _mapper = mapper;
        _surveyQuestionService = surveyQuestionService;   
    }

    public async Task<CreatedSurveyResponse> Add(CreateSurveyRequest createSurveyRequest)
    {
        // Yeni bir anket oluştur
        Survey survey = _mapper.Map<Survey>(createSurveyRequest);

        // SurveyDal üzerinden anketi ekleyin
        Survey createdSurvey = await _surveyDal.AddAsync(survey);

        // Oluşturulan anketin gerçek ID'sini alın
        int surveyId = createdSurvey.Id;

        // Geçici bir ID kullanarak SurveyQuestion'ları oluştur ve ilişkilendir
        foreach (var questionDto in createSurveyRequest.Questions)
        {
            // SurveyQuestion DTO'sunu AddSurveyQuestionRequest'e dönüştür
            AddSurveyQuestionRequest addSurveyQuestionRequest = _mapper.Map<AddSurveyQuestionRequest>(questionDto);

            // Gerçek anket ID'sini ayarla
            addSurveyQuestionRequest.SurveyID = surveyId;

            // Yeni oluşturulan anket sorusunu ekle
            await _surveyQuestionService.Add(addSurveyQuestionRequest);
        }


        // Oluşturulan anketi uygun DTO'ya dönüştürün
        CreatedSurveyResponse createdSurveyResponse = _mapper.Map<CreatedSurveyResponse>(createdSurvey);

        // Oluşturulan anketin yanıtları ve sorularıyla birlikte cevabı döndürün
        return createdSurveyResponse;
    }



    public async Task<DeletedSurveyResponse> Delete(DeleteSurveyRequest deleteSurveyRequest)
    {
        var data = await _surveyDal.GetAsync(i => i.Id == deleteSurveyRequest.Id);
        _mapper.Map(deleteSurveyRequest, data);
        var result = await _surveyDal.DeleteAsync(data);
        var result2 = _mapper.Map<DeletedSurveyResponse>(result);
        return result2;
    }

    public async Task<GetByIdSurveyResponse> GetById(int id)
    {
        var result = await _surveyDal.GetAsync(
            s => s.Id == id,
            include: sa => sa.Include(sa => sa.SurveyQuestions.Where(sq => sq.SurveyID == id))
        );

        Console.WriteLine("Gelen result: " + result);

        GetByIdSurveyResponse customResponse = _mapper.Map<GetByIdSurveyResponse>(result);

        // Özel survey question response'ları oluştur
        customResponse.SurveyQuestions = result.SurveyQuestions
            .Select(sq => new GetSurveyQuestionResponse
            {
                QuestionId = sq.Id,
                QuestionText = sq.QuestionText,
                QuestionType = sq.QuestionType
                // Diğer özellikler...
            })
            .ToList();

        return customResponse;
    }


    public async Task<IPaginate<GetListSurveyResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _surveyDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );
        var result = _mapper.Map<Paginate<GetListSurveyResponse>>(data);
        return result;
    }

    public async Task<UpdatedSurveyResponse> Update(UpdateSurveyRequest updateSurveyRequest)
    {
        var data = await _surveyDal.GetAsync(i => i.Id == updateSurveyRequest.Id);
        _mapper.Map(updateSurveyRequest, data);
        await _surveyDal.UpdateAsync(data);
        var result = _mapper.Map<UpdatedSurveyResponse>(data);
        return result;
    }
    public async Task<List<GetListSurveyResponse>> GetUnsentSurveysAsync(Guid userId)
    {

        var answeredSurveyIds = await _surveyDal.GetListAsync(sa => sa.SurveyAnswers.Any(sar => sar.UserID == userId));
        var allSurveyIds = await _surveyDal.GetListAsync(size: int.MaxValue, index: 0);
        var unsentSurveyIds = allSurveyIds.Items.Select(s => s.Id).Except(answeredSurveyIds.Items.Select(sa => sa.Id)).ToList();

        var unsentSurveysResult = await _surveyDal.GetListAsync(survey => unsentSurveyIds.Contains(survey.Id));

        // Items özelliği üzerinden anketlere eriş ve projeksiyon yap
        var unsentSurveyResponses = unsentSurveysResult.Items
            .OfType<Survey>() // Eğer Items bir IEnumerable ise, OfType ile uygun tipi seçebilirsiniz.
            .Select(survey => _mapper.Map<GetListSurveyResponse>(survey))
            .ToList();

        return unsentSurveyResponses;
    }




}