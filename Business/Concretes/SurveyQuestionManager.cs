

using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.SurveyQuestion;
using Business.DTOs.Response.SurveyQuestion;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Surveys;

namespace Business.Concretes
    {
        public class SurveyQuestionManager : ISurveyQuestionService
        {
            private readonly ISurveyQuestionDal _surveyQuestionDal;
            private readonly IMapper _mapper;

            public SurveyQuestionManager(ISurveyQuestionDal surveyQuestionDal, IMapper mapper)
            {
                _surveyQuestionDal = surveyQuestionDal;
                _mapper = mapper;
            }

            public async Task<IPaginate<GetListSurveyQuestionResponse>> GetListAsync(PageRequest pageRequest)
            {
                var data = await _surveyQuestionDal.GetListAsync(
                    index: pageRequest.PageIndex,
                    size: pageRequest.PageSize
                );
                var result = _mapper.Map<Paginate<GetListSurveyQuestionResponse>>(data);
                return result;
            }

  

            public async Task<CreatedSurveyQuestionResponse> Add(AddSurveyQuestionRequest addSurveyQuestionRequest)
            {
                var surveyQuestion = _mapper.Map<SurveyQuestion>(addSurveyQuestionRequest);
                var createdSurveyQuestion = await _surveyQuestionDal.AddAsync(surveyQuestion);
                var createdSurveyQuestionResponse = _mapper.Map<CreatedSurveyQuestionResponse>(createdSurveyQuestion);
                return createdSurveyQuestionResponse;
            }

            public async Task<UpdatedSurveyQuestionResponse> Update(UpdateSurveyQuestionRequest updateSurveyQuestionRequest)
            {
                var existingSurveyQuestion = await _surveyQuestionDal.GetAsync(s => s.Id == updateSurveyQuestionRequest.Id);
                if (existingSurveyQuestion == null)
                {
                    // Handle the case where the survey question is not found
                    // You can throw an exception or return an appropriate response
                    return null;
                }

                _mapper.Map(updateSurveyQuestionRequest, existingSurveyQuestion);
                await _surveyQuestionDal.UpdateAsync(existingSurveyQuestion);
                var updatedSurveyQuestionResponse = _mapper.Map<UpdatedSurveyQuestionResponse>(existingSurveyQuestion);
                return updatedSurveyQuestionResponse;
            }

            public async Task<DeletedSurveyQuestionResponse> Delete(DeleteSurveyQuestionRequest deleteSurveyQuestionRequest)
            {
                var existingSurveyQuestion = await _surveyQuestionDal.GetAsync(s => s.Id == deleteSurveyQuestionRequest.Id);
                if (existingSurveyQuestion == null)
                {
                    // Handle the case where the survey question is not found
                    // You can throw an exception or return an appropriate response
                    return null;
                }

                var result = await _surveyQuestionDal.DeleteAsync(existingSurveyQuestion);
                var deletedSurveyQuestionResponse = _mapper.Map<DeletedSurveyQuestionResponse>(result);
                return deletedSurveyQuestionResponse;
            }

            public async Task<GetSurveyQuestionResponse> GetById(int id)
            {
                var result = await _surveyQuestionDal.GetAsync(s => s.Id == id);
                var mappedSurveyQuestion = _mapper.Map<GetSurveyQuestionResponse>(result);
                return mappedSurveyQuestion;
            }
        }
    }

