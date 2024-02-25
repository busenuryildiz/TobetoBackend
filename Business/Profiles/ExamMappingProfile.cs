using AutoMapper;
using Business.DTOs.Request.Exam;
using Business.DTOs.Response.Exam;
using Business.DTOs.Response.Question;
using Core.DataAccess.Paging;
using Entities.Concretes.CoursesFolder;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            //--------------------Created---------------------------------------

            CreateMap<CreateExamRequest, Exam>().ReverseMap();
            CreateMap<Exam, CreatedExamResponse>().ReverseMap();
            CreateMap<CreateExamRequest, CreatedExamResponse>().ReverseMap();


            //-------------------Deleted----------------------------------------------

            CreateMap<DeleteExamRequest, Exam>().ReverseMap();
            CreateMap<Exam, DeletedExamResponse>().ReverseMap();
            CreateMap<DeleteExamRequest, DeletedExamResponse>().ReverseMap();

            //-------------------Updated---------------------------------------------
            CreateMap<UpdateExamRequest, Exam>().ReverseMap();
            CreateMap<Exam, UpdatedExamResponse>().ReverseMap();
            CreateMap<UpdateExamRequest, UpdatedExamResponse>().ReverseMap();

            //--------------------Listeleme-----------------------------------

            CreateMap<Exam, GetListExamResponse>().ReverseMap();
            CreateMap<Paginate<Exam>, Paginate<GetListExamResponse>>().ReverseMap();


            CreateMap<CreateExamRequest, Exam>()
             .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

            CreateMap<CreateQuestionDto, Question>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));

            CreateMap<Question, GetListQuestionResponse>();

            CreateMap<Option, GetOptionResponse>();

            CreateMap<StudentExamResult, StudentExamResultDto>()
         .ForMember(dest => dest.CorrectAnswers, opt => opt.MapFrom(src => src.CorrectAnswers))
         .ForMember(dest => dest.WrongAnswers, opt => opt.MapFrom(src => src.WrongAnswers))
         .ForMember(dest => dest.Unanswered, opt => opt.MapFrom(src => src.Unanswered));

            CreateMap<CreateOptionDto, Option>();

        }
    }
}
