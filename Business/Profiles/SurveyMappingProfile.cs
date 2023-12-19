using AutoMapper;
using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<CreateSurveyRequest, Survey>().ReverseMap();
            CreateMap<UpdateSurveyRequest, Survey>().ReverseMap();
            CreateMap<Survey, SurveyResponse>().ReverseMap();
        }
    }

}
