
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
    using static System.Runtime.InteropServices.JavaScript.JSType;

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
                SurveyAnswer surveyAnswer = _mapper.Map<SurveyAnswer>(addSurveyAnswerRequestOne);
                var createdSurveyAnswer = await _surveyAnswerDal.AddAsync(surveyAnswer);
                Log.Information("veri ", surveyAnswer);
                var createdSurveyAnswerResponse = _mapper.Map<CreatedSurveyAnswerResponse>(createdSurveyAnswer);
                createdSurveyAnswers.Add(createdSurveyAnswerResponse);
            }

            return createdSurveyAnswers;
        }

        public async Task<Dictionary<string, double>> GetSurveyAnswerAverages(Guid userId, int surveyId)
        {
            try
            {
                var paginatedResult = _surveyAnswerDal.GetList(
     predicate: answer => answer.UserID == userId && answer.SurveyID == surveyId,
     include: query => query.Include(answer => answer.SurveyQuestion)
 );
                var dataList = paginatedResult.Items.ToList();

                if (!dataList.Any())
                {
                    return new Dictionary<string, double>(); // Boş bir sözlük döndür
                }

                var groupedData = dataList.GroupBy(item => item.SurveyQuestion != null ? item.SurveyQuestion.QuestionType : "Unknown");

                var categoryAverages = new Dictionary<string, double>();

                foreach (var group in groupedData)
                {
                    var answers = new List<int>();

                    foreach (var answer in group)
                    {
                        answers.Add(Convert.ToInt32(answer.AnswerValue));
                    }

                    var average = answers.Any() ? answers.Average() : 0;
                    categoryAverages[group.Key] = average;
                }

                return categoryAverages;
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir şekilde işleyin veya loglayın.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

    }
}

