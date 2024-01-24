using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Surveys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class SurveyManager : ISurveyService
    {
        private readonly ISurveyDal _surveyDal;
        private readonly IMapper _mapper;

        public SurveyManager( ISurveyDal surveyDal, IMapper mapper)
        {
            _surveyDal = surveyDal;
            _mapper = mapper;
        }

        public async Task<CreatedSurveyResponse> Add(CreateSurveyRequest createSurveyRequest)
        {
            // Burada iş kuralları kontrol edilebilir, gerekirse _businessRules nesnesi kullanılabilir.

            Survey survey = _mapper.Map<Survey>(createSurveyRequest);
            Survey createdSurvey = await _surveyDal.AddAsync(survey);
            CreatedSurveyResponse createdSurveyResponse = _mapper.Map<CreatedSurveyResponse>(createdSurvey);
            return createdSurveyResponse;
        }

        public async Task<DeletedSurveyResponse> Delete(DeleteSurveyRequest deleteSurveyRequest)
        {
            // Burada iş kuralları kontrol edilebilir, gerekirse _businessRules nesnesi kullanılabilir.

            var data = await _surveyDal.GetAsync(predicate: i => i.Id == deleteSurveyRequest.Id);
            _mapper.Map(deleteSurveyRequest, data);
            var result = await _surveyDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedSurveyResponse>(result);
            return result2;
        }


        public async Task<CreatedSurveyResponse> GetById(int id)
        {
            var result = await _surveyDal.GetAsync(c => c.Id == id);
            Survey mappedSurvey = _mapper.Map<Survey>(result);
            CreatedSurveyResponse createdSurveyResponse = _mapper.Map<CreatedSurveyResponse>(mappedSurvey);
            return createdSurveyResponse;
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
            // Burada iş kuralları kontrol edilebilir, gerekirse _businessRules nesnesi kullanılabilir.

            var data = await _surveyDal.GetAsync(i => i.Id == updateSurveyRequest.Id);
            _mapper.Map(updateSurveyRequest, data);
            await _surveyDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedSurveyResponse>(data);
            return result;
        }

        // Diğer metotları da burada implemente edebilirsiniz.
    }
}
