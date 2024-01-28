using Business.DTOs.Request.Survey;
using Business.DTOs.Request.SurveyAnswer;
using Business.DTOs.Response.Survey;
using Business.DTOs.Response.SurveyAnswer;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }

}
