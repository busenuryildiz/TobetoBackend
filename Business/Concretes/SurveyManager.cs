using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SurveyManager : ISurveyService
    {
        private readonly ISurveyDal _surveyDal;
        private readonly IMapper _mapper;

        public SurveyManager(ISurveyDal surveyDal, IMapper mapper)
        {
            _surveyDal = surveyDal ?? throw new ArgumentNullException(nameof(surveyDal));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<SurveyResponse>> GetSurveysAsync()
        {
            var surveys = await _surveyDal.GetListAsync();
            return _mapper.Map<List<SurveyResponse>>(surveys);
        }

        public async Task<SurveyResponse> GetSurveyByIdAsync(int id)
        {
            var survey = await _surveyDal.GetAsync(s => s.Id == id);
            return _mapper.Map<SurveyResponse>(survey);
        }

        public async Task<SurveyResponse> CreateSurveyAsync(CreateSurveyRequest request)
        {
            var survey = _mapper.Map<Survey>(request);
            survey = await _surveyDal.AddAsync(survey);
            return _mapper.Map<SurveyResponse>(survey);
        }

        public async Task<SurveyResponse> UpdateSurveyAsync(UpdateSurveyRequest request)
        {
            var existingSurvey = await _surveyDal.GetAsync(s => s.Id == request.Id);
            if (existingSurvey == null)
            {
                // Handle not found scenario
                return null;
            }

            _mapper.Map(request, existingSurvey);
            existingSurvey = await _surveyDal.UpdateAsync(existingSurvey);
            return _mapper.Map<SurveyResponse>(existingSurvey);
        }

        public async Task DeleteSurveyAsync(DeleteSurveyRequest request)
        {
            var existingSurvey = await _surveyDal.GetAsync(s => s.Id == request.Id);
            if (existingSurvey != null)
            {
                await _surveyDal.DeleteAsync(existingSurvey);
            }
        }
    }

}
