using AutoMapper;
using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using Core.DataAccess.Paging;
using Entities.Concretes.Surveys;
using System.Collections.Generic;

namespace Business.Profiles
{
    public class SurveyManagerMappingProfile : Profile
    {
        public SurveyManagerMappingProfile()
        {
            CreateMap<CreateSurveyRequest, Survey>().ReverseMap();
            CreateMap<Survey, CreatedSurveyResponse>().ReverseMap();

            CreateMap<UpdateSurveyRequest, Survey>().ReverseMap();
            CreateMap<Survey, UpdatedSurveyResponse>().ReverseMap();

            CreateMap<DeleteSurveyRequest, Survey>().ReverseMap();
            CreateMap<Survey, DeletedSurveyResponse>().ReverseMap();

            CreateMap<Survey, GetSurveyDetailResponse>().ReverseMap();

            CreateMap<SurveyQuestion, GetSurveyQuestionResponse>().ReverseMap();
            CreateMap<ICollection<SurveyQuestion>, ICollection<GetSurveyQuestionResponse>>().ReverseMap();

            CreateMap<Paginate<Survey>, Paginate<GetListSurveyResponse>>().ReverseMap();
        }
    }
}
