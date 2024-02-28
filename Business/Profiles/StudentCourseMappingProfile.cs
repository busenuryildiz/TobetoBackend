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
using Business.DTOs.Response.Lesson;
using Business.DTOs.Response.StudentLesson;

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
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course.Id))
                .ForMember(dest => dest.StudentCourseId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.CourseDate, opt => opt.MapFrom(src => src.Course.CreatedDate))
                .ForMember(dest => dest.CourseImagePath, opt => opt.MapFrom(src => src.Course.ImagePath))
                .ForMember(dest => dest.StudentCourseProgress, opt => opt.MapFrom(src => src.Progress));


            CreateMap<IPaginate<StudentCourse>, List<GeneralStudentCourseList>>()
                .ConvertUsing((src, dest, context) =>
                {
                    return context.Mapper.Map<List<GeneralStudentCourseList>>(src.Items);
                });


            CreateMap<StudentCourse, CoursesAllLessonInfoResponse>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course.Id))
                .ForMember(dest => dest.StudentCourseId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.CourseImagePath, opt => opt.MapFrom(src => src.Course.ImagePath))
                .ForMember(dest => dest.Point, opt => opt.MapFrom(src => src.Course.Point))
                .ForMember(dest => dest.AreasOfInterest, opt => opt.MapFrom(src => src.Course.AreasOfInterest))
                .ForMember(dest => dest.StudentCourseIsLiked, opt => opt.MapFrom(src => src.Liked))
                .ForMember(dest => dest.StudentCourseIsSaved, opt => opt.MapFrom(src => src.Saved))
                .ForMember(dest => dest.StudentCourseProgress, opt => opt.MapFrom(src => src.Progress))
                .ForMember(dest => dest.CourseProducerCompany, opt => opt.MapFrom(src => src.Course.ProducerCompany))
                .ForMember(dest => dest.CourseCategoryNames, opt => opt.MapFrom(src => src.Course.CategoryNames))
                .ForMember(dest => dest.StudentCourseStartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.StudentCourseSpentTime, opt => opt.MapFrom(src => src.SpentTime))
                .ForMember(dest => dest.StudentCourseEstimatedTime, opt => opt.MapFrom(src => src.EstimatedTime))
                .ForMember(dest => dest.GetListLessonResponses, opt => opt.MapFrom(src => src.Course.Lessons))
                .ForMember(dest => dest.GetListStudentLessonResponses, opt => opt.MapFrom(src =>
                                                 src.Course.Lessons.SelectMany(lesson => lesson.StudentLessons)));




        }
    }
}
