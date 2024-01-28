using AutoMapper;
using Business.DTOs.Request.SurveyAnswer;
using Business.DTOs.Response.Subject;
using Business.DTOs.Response.SurveyAnswer;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Surveys;

namespace Business.Profiles
{
    public class SurveyAnswerMappingProfile : Profile
    {
        public SurveyAnswerMappingProfile()
        {
            CreateMap<AddSurveyAnswerRequest, SurveyAnswer>().ReverseMap();
            CreateMap<UpdateSurveyAnswerRequest, SurveyAnswer>().ReverseMap();
            CreateMap<DeleteSurveyAnswerRequest, SurveyAnswer>().ReverseMap();

            CreateMap<SurveyAnswer, GetSurveyAnswerResponse>()
                .ForMember(dest => dest.SurveyQuestionText, opt => opt.MapFrom(src => src.SurveyQuestion.QuestionText))
                .ForMember(dest => dest.SurveyQuestionType, opt => opt.MapFrom(src => src.SurveyQuestion.QuestionType));
            CreateMap<SurveyAnswer, GetListSurveyAnswerResponse>().ReverseMap();
            CreateMap<SurveyAnswer, CreatedSurveyAnswerResponse>().ReverseMap();
            CreateMap<SurveyAnswer, UpdatedSurveyAnswerResponse>().ReverseMap();
            CreateMap<SurveyAnswer, DeletedSurveyAnswerResponse>().ReverseMap();

            CreateMap<Paginate<SurveyAnswer>, Paginate<GetSurveyAnswerResponse>>();

        }
    }
}
