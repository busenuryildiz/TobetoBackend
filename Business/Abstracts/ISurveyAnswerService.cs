using Business.DTOs.Request.SurveyAnswer;
using Business.DTOs.Response.SurveyAnswer;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ISurveyAnswerService
    {
        Task<IPaginate<GetListSurveyAnswerResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedSurveyAnswerResponse> Add(AddSurveyAnswerRequest addSurveyAnswerRequest);
        Task<UpdatedSurveyAnswerResponse> Update(UpdateSurveyAnswerRequest updateSurveyAnswerRequest);
        Task<DeletedSurveyAnswerResponse> Delete(DeleteSurveyAnswerRequest deleteSurveyAnswerRequest);
        Task<GetSurveyAnswerResponse> GetById(int id);
        Task<IPaginate<GetSurveyAnswerResponse>> GetUserSurveyAnswers(Guid userId, int surveyId);
        Task<List<CreatedSurveyAnswerResponse>> SubmitAnswers(List<AddSurveyAnswerRequest> addSurveyAnswerRequests);
        Task<Dictionary<int, double>> CalculateQuestionAverages();
    }

}
