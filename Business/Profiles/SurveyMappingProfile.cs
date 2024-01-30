using AutoMapper;
using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    using AutoMapper;
    using Core.DataAccess.Paging;
    using Entities.Concretes.Surveys;

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

            CreateMap<Survey, GetByIdSurveyResponse>()
            .ForMember(dest => dest.SurveyQuestions, opt => opt.MapFrom(src => src.SurveyQuestions));
    

            CreateMap<SurveyQuestion, GetSurveyQuestionResponse>()
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.Id));
            // Diğer özellikleri de belirtmek istiyorsanız burada tanımlayabilirsiniz.


        }
    }


}
