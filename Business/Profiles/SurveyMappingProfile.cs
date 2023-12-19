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
    using AutoMapper;
    using Core.DataAccess.Paging;

    public class SurveyMappingProfile : Profile
    {
        public SurveyMappingProfile()
        {
            CreateMap<CreateSurveyRequest, Survey>().ReverseMap();
            CreateMap<Survey, CreatedSurveyResponse>().ReverseMap();

            CreateMap<DeleteSurveyRequest, Survey>().ReverseMap();
            CreateMap<Survey, DeletedSurveyResponse>().ReverseMap();

            CreateMap<UpdateSurveyRequest, Survey>().ReverseMap();
            CreateMap<Survey, UpdatedSurveyResponse>().ReverseMap();

            CreateMap<Survey, GetListSurveyResponse>().ReverseMap();
            CreateMap<Paginate<Survey>, Paginate<GetListSurveyResponse>>().ReverseMap();
        }
    }


}
