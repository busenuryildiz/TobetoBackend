using AutoMapper;
using Business.DTOs.Request.Course;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Course;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using Entities.Concretes.Clients;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<CreateCourseRequest, Course>().ReverseMap();
            CreateMap<Course, CreatedCourseResponse>().ReverseMap();

            CreateMap<CoursePart, CoursePartResponse>().ReverseMap();
            CreateMap<Lesson, LessonResponse>().ReverseMap();

            CreateMap<DeleteCourseRequest, Course>().ReverseMap();
            CreateMap<Course, DeletedCourseResponse>().ReverseMap();

            CreateMap<UpdateCourseRequest, Course>().ReverseMap();
            CreateMap<Course, UpdatedCourseResponse>().ReverseMap();

            CreateMap<Course, GetListCourseResponse>()
                .ForMember(dest => dest.InstructorName, opt =>
                    opt.MapFrom(src => GetInstructorName(src)))
                .ForMember(dest => dest.CategoryName, opt =>
                    opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
                .ForMember(dest => dest.CourseLevelName, opt =>
                    opt.MapFrom(src => src.CourseLevel != null ? src.CourseLevel.Name : null))
                .ForMember(dest => dest.SoftwareLanguageName, opt =>
                    opt.MapFrom(src => src.SoftwareLanguage != null ? src.SoftwareLanguage.Name : null))
                .ForMember(dest => dest.CourseSubjectName, opt =>
                    opt.MapFrom(src => GetCourseSubjectName(src)))
                .ReverseMap();

            CreateMap<Paginate<Course>, Paginate<GetListCourseResponse>>().ReverseMap();
        }

        private string GetInstructorName(Course course)
        {
            var instructorCourse = course.InstructorCourses.FirstOrDefault();
            if (instructorCourse != null && instructorCourse.Instructor != null && instructorCourse.Instructor.User != null)
                return $"{instructorCourse.Instructor.User.FirstName} {instructorCourse.Instructor.User.LastName}";
            return null;
        }

        private string GetCourseSubjectName(Course course)
        {
            var courseSubject = course.CourseSubjects.FirstOrDefault();
            if (courseSubject != null && courseSubject.Subject != null)
                return courseSubject.Subject.Name;
            return null;
        }
    }
}
