using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISurveyService
    {
        Task<IPaginate<GetListSurveyResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedSurveyResponse> Create(CreateSurveyRequest createSurveyRequest);
        Task<UpdatedSurveyResponse> Update(UpdateSurveyRequest updateSurveyRequest);
        Task<DeletedSurveyResponse> Delete(DeleteSurveyRequest deleteSurveyRequest);
        Task<GetSurveyDetailResponse> GetDetail(int surveyId);
        Task<ICollection<GetSurveyQuestionResponse>> GetSurveyQuestions(int surveyId);
    }

}
