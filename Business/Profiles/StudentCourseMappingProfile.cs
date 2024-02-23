using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Response.StudentCourse;
using Core.DataAccess.Paging;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Response.UserLanguage;
using Entities.Concretes.Profiles;
using Business.DTOs.Response.ExamOfUser;

namespace Business.Profiles
{
    public class StudentCourseMappingProfile : Profile
    {
        public StudentCourseMappingProfile()
        {
            CreateMap<CreateStudentCourseRequest, StudentCourse>().ReverseMap();
            CreateMap<StudentCourse, CreatedStudentCourseResponse>().ReverseMap();

            CreateMap<DeleteStudentCourseRequest, StudentCourse>().ReverseMap();
            CreateMap<StudentCourse, DeletedStudentCourseResponse>().ReverseMap();

            CreateMap<StudentCourse, GetListStudentCourseResponse>()
                .ForMember(dest => dest.course, opt => opt.MapFrom(src => src.Course));


            CreateMap<UpdateStudentCourseRequest, StudentCourse>().ReverseMap();
            CreateMap<StudentCourse, UpdatedStudentCourseResponse>().ReverseMap();



            CreateMap<Paginate<StudentCourse>, Paginate<GetListStudentCourseResponse>>().ReverseMap();


            CreateMap<StudentCourse, GetUserBadgesResponse>()
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Student.UserId))
                 .ForMember(dest => dest.StudentCourseId, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course.Id))
                 .ForMember(dest => dest.BadgePath, opt => opt.MapFrom(src => src.Course.BadgePath));


            CreateMap<IPaginate<StudentCourse>, List<GetUserBadgesResponse>>()
                 .ConvertUsing((src, dest, context) =>
                 {
                     return context.Mapper.Map<List<GetUserBadgesResponse>>(src.Items);
                 });


            CreateMap<StudentCourse, GeneralStudentCourseList>()
                .ForMember(dest => dest.StudentCourseId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StudentCourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.StudentCourseDate, opt => opt.MapFrom(src => src.Course.CreatedDate))
                .ForMember(dest => dest.StudentCourseImagePath, opt => opt.MapFrom(src => src.Course.ImagePath))
                .ForMember(dest => dest.StudentCourseProgress, opt => opt.MapFrom(src => src.Progress));


            CreateMap<IPaginate<StudentCourse>, List<GeneralStudentCourseList>>()
                .ConvertUsing((src, dest, context) =>
                {
                    return context.Mapper.Map<List<GeneralStudentCourseList>>(src.Items);
                });


        }
    }
}
