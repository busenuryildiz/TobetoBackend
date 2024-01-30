
using Business.DTOs.Request.SurveyQuestion;
using Business.DTOs.Response.SurveyQuestion;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISurveyQuestionService
    {
        Task<IPaginate<GetListSurveyQuestionResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedSurveyQuestionResponse> Add(AddSurveyQuestionRequest addSurveyQuestionRequest);
        Task<UpdatedSurveyQuestionResponse> Update(UpdateSurveyQuestionRequest updateSurveyQuestionRequest);
        Task<DeletedSurveyQuestionResponse> Delete(DeleteSurveyQuestionRequest deleteSurveyQuestionRequest);
        Task<GetSurveyQuestionResponse> GetById(int id);
    }
}
