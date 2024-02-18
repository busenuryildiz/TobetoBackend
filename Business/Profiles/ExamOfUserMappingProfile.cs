using AutoMapper;
using Business.DTOs.Request.ExamOfUser;
using Business.DTOs.Response.ExamOfUser;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
     public class ExamOfUserMappingProfile : Profile
    {
        public ExamOfUserMappingProfile()
        {
            CreateMap<CreateExamOfUserRequest, ExamOfUser>().ReverseMap();
            CreateMap<ExamOfUser, CreatedExamOfUserResponse>().ReverseMap();

            CreateMap<DeleteExamOfUserRequest, ExamOfUser>().ReverseMap();
            CreateMap<ExamOfUser, DeletedExamOfUserResponse>().ReverseMap();

            CreateMap<UpdateExamOfUserRequest, ExamOfUser>().ReverseMap();
            CreateMap<ExamOfUser, UpdatedExamOfUserResponse>().ReverseMap();

            CreateMap<ExamOfUser, GetListExamOfUserResponse>().ReverseMap();
            CreateMap<Paginate<ExamOfUser>, Paginate<GetListExamOfUserResponse>>().ReverseMap();

            CreateMap<ExamOfUser, GetUsersExamResultInfoResponse>()
                .ForMember(dest => dest.ExamTitle, opt => opt.MapFrom(src => src.Exam.Title))
                .ForMember(dest => dest.ExamDescription, opt => opt.MapFrom(src => src.Exam.Description))
                .ForMember(dest => dest.ExamDate, opt => opt.MapFrom(src => src.Exam.Date))
                .ForMember(dest => dest.ExamResult, opt => opt.MapFrom(src => src.ExamResult))
                .ReverseMap();

            CreateMap<Paginate<ExamOfUser>, Paginate<GetUsersExamResultInfoResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));


        }
    }
}
