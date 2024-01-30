using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using Core.DataAccess.Paging;

public interface ISurveyService
{
    Task<IPaginate<GetListSurveyResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedSurveyResponse> Add(CreateSurveyRequest createSurveyRequest);
    Task<UpdatedSurveyResponse> Update(UpdateSurveyRequest updateSurveyRequest);
    Task<DeletedSurveyResponse> Delete(DeleteSurveyRequest deleteSurveyRequest);
    Task<GetByIdSurveyResponse> GetById(int id);
    Task<List<GetListSurveyResponse>> GetUnsentSurveysAsync(Guid userId);
  
}