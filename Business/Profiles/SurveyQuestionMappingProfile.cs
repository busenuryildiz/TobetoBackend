using AutoMapper;
using Business.DTOs.Request.SurveyQuestion;
using Business.DTOs.Response.SurveyQuestion;
using Entities.Concretes.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SurveyQuestionMappingProfile : Profile
    {
        public SurveyQuestionMappingProfile()
        {
            CreateMap<AddSurveyQuestionRequest, SurveyQuestion>().ReverseMap();
            CreateMap<UpdateSurveyQuestionRequest, SurveyQuestion>().ReverseMap();
            CreateMap<DeleteSurveyQuestionRequest, SurveyQuestion>().ReverseMap();

            CreateMap<SurveyQuestion, GetSurveyQuestionResponse>().ReverseMap();
            CreateMap<SurveyQuestion, GetListSurveyQuestionResponse>().ReverseMap();
            CreateMap<SurveyQuestion, CreatedSurveyQuestionResponse>().ReverseMap();
            CreateMap<SurveyQuestion, UpdatedSurveyQuestionResponse>().ReverseMap();
            CreateMap<SurveyQuestion, DeletedSurveyQuestionResponse>().ReverseMap();
        }
    }
}
