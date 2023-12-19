using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISurveyService
    {
        Task<List<SurveyResponse>> GetSurveysAsync();
        Task<SurveyResponse> GetSurveyByIdAsync(int id);
        Task<SurveyResponse> CreateSurveyAsync(CreateSurveyRequest request);
        Task<SurveyResponse> UpdateSurveyAsync(UpdateSurveyRequest request);
        Task DeleteSurveyAsync(DeleteSurveyRequest request);
    }

}
