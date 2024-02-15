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
            // CreateSurveyRequest ile Survey arasında eşleme
            CreateMap<CreateSurveyRequest, Survey>().ReverseMap();

            // DeleteSurveyRequest ile Survey arasında eşleme
            CreateMap<DeleteSurveyRequest, Survey>().ReverseMap();

            // UpdateSurveyRequest ile Survey arasında eşleme
            CreateMap<UpdateSurveyRequest, Survey>().ReverseMap();

            // Survey ile CreatedSurveyResponse arasında eşleme
            CreateMap<Survey, CreatedSurveyResponse>().ReverseMap();

            // Survey ile DeletedSurveyResponse arasında eşleme
            CreateMap<Survey, DeletedSurveyResponse>().ReverseMap();

            // Survey ile UpdatedSurveyResponse arasında eşleme
            CreateMap<Survey, UpdatedSurveyResponse>().ReverseMap();

            // Survey ile GetListSurveyResponse arasında eşleme
            CreateMap<Survey, GetListSurveyResponse>().ReverseMap();

            // Paginate<Survey> ile Paginate<GetListSurveyResponse> arasında eşleme
            CreateMap<Paginate<Survey>, Paginate<GetListSurveyResponse>>().ReverseMap();

            // Survey ile GetByIdSurveyResponse arasında eşleme
            CreateMap<Survey, GetByIdSurveyResponse>()
                .ForMember(dest => dest.SurveyQuestions, opt => opt.MapFrom(src => src.SurveyQuestions));

            // SurveyQuestion ile GetSurveyQuestionResponse arasında eşleme
            CreateMap<SurveyQuestion, GetSurveyQuestionResponse>()
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.QuestionText))
                .ForMember(dest => dest.QuestionType, opt => opt.MapFrom(src => src.QuestionType))
                // Diğer özellikleri de belirtmek istiyorsanız burada tanımlayabilirsiniz.
                .ReverseMap(); // Ters yönlü eşleme için

            // SurveyAnswer ile diğer DTO'lar arasında eşlemeleri burada yapabilirsiniz
        }
    }


}
