
namespace Business.Concretes
{
    using AutoMapper;

    using Core.DataAccess.Paging;
    using DataAccess.Abstracts;
    using Entities.Concretes.Surveys;
    using global::Business.Abstracts;
    using global::Business.DTOs.Request.SurveyAnswer;
    using global::Business.DTOs.Response.SurveyAnswer;
    using Microsoft.EntityFrameworkCore;
    using Serilog;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SurveyAnswerManager : ISurveyAnswerService
    {
        private readonly ISurveyAnswerDal _surveyAnswerDal;
        private readonly IMapper _mapper;

        public SurveyAnswerManager(ISurveyAnswerDal surveyAnswerDal, IMapper mapper)
        {
            _surveyAnswerDal = surveyAnswerDal;
            _mapper = mapper;
        }

        public async Task<IPaginate<GetListSurveyAnswerResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _surveyAnswerDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListSurveyAnswerResponse>>(data);
            return result;
        }

        public async Task<CreatedSurveyAnswerResponse> Add(AddSurveyAnswerRequest addSurveyAnswerRequest)
        {
            var surveyAnswer = _mapper.Map<SurveyAnswer>(addSurveyAnswerRequest);
            var createdSurveyAnswer = await _surveyAnswerDal.AddAsync(surveyAnswer);
            var createdSurveyAnswerResponse = _mapper.Map<CreatedSurveyAnswerResponse>(createdSurveyAnswer);
            return createdSurveyAnswerResponse;
        }

        public async Task<UpdatedSurveyAnswerResponse> Update(UpdateSurveyAnswerRequest updateSurveyAnswerRequest)
        {
            var existingSurveyAnswer = await _surveyAnswerDal.GetAsync(sa => sa.Id == updateSurveyAnswerRequest.Id);
            if (existingSurveyAnswer == null)
            {
                // Handle the case where the survey answer is not found
                // You can throw an exception or return an appropriate response
                return null;
            }

            _mapper.Map(updateSurveyAnswerRequest, existingSurveyAnswer);
            await _surveyAnswerDal.UpdateAsync(existingSurveyAnswer);
            var updatedSurveyAnswerResponse = _mapper.Map<UpdatedSurveyAnswerResponse>(existingSurveyAnswer);
            return updatedSurveyAnswerResponse;
        }

        public async Task<DeletedSurveyAnswerResponse> Delete(DeleteSurveyAnswerRequest deleteSurveyAnswerRequest)
        {
            var existingSurveyAnswer = await _surveyAnswerDal.GetAsync(sa => sa.Id == deleteSurveyAnswerRequest.Id);
            if (existingSurveyAnswer == null)
            {
                // Handle the case where the survey answer is not found
                // You can throw an exception or return an appropriate response
                return null;
            }

            var result = await _surveyAnswerDal.DeleteAsync(existingSurveyAnswer);
            var deletedSurveyAnswerResponse = _mapper.Map<DeletedSurveyAnswerResponse>(result);
            return deletedSurveyAnswerResponse;
        }

        public async Task<GetSurveyAnswerResponse> GetById(int id)
        {
            var result = await _surveyAnswerDal.GetAsync(sa => sa.Id == id);
            var mappedSurveyAnswer = _mapper.Map<GetSurveyAnswerResponse>(result);
            return mappedSurveyAnswer;
        }

        public async Task<IPaginate<GetSurveyAnswerResponse>> GetUserSurveyAnswers(Guid userId, int surveyId)
        {
            var surveyAnswers = await _surveyAnswerDal.GetListAsync(
      sa => sa.SurveyID == surveyId && sa.UserID == userId,
      include: sa => sa.Include(sa => sa.SurveyQuestion)
            );

            var mappedSurveyAnswers = _mapper.Map<Paginate<GetSurveyAnswerResponse>>(surveyAnswers);
            return mappedSurveyAnswers;
        }


        public async Task<List<CreatedSurveyAnswerResponse>> SubmitAnswers(List<AddSurveyAnswerRequest> addSurveyAnswerRequests)
        {
            var createdSurveyAnswers = new List<CreatedSurveyAnswerResponse>();

            foreach (var addSurveyAnswerRequestOne in addSurveyAnswerRequests)
            {
                // Map AddSurveyAnswerRequest to SurveyAnswer entity
                SurveyAnswer surveyAnswer = _mapper.Map<SurveyAnswer>(addSurveyAnswerRequestOne);

                // Add the survey answer to the database
                var createdSurveyAnswer = await _surveyAnswerDal.AddAsync(surveyAnswer);
                Log.Information("veri ", surveyAnswer);

                // Map the created survey answer to response DTO
                var createdSurveyAnswerResponse = _mapper.Map<CreatedSurveyAnswerResponse>(createdSurveyAnswer);

                // Add the response to the list
                createdSurveyAnswers.Add(createdSurveyAnswerResponse);
            }

            return createdSurveyAnswers;
        }


    }
}

