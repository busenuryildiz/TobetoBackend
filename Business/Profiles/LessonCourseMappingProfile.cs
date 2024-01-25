using AutoMapper;
using Business.DTOs.Request.LessonCourse;
using Business.DTOs.Response.LessonCourse;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Courses;

namespace Business.Profiles
{
    public class LessonCourseMappingProfile : Profile
    {
        public LessonCourseMappingProfile()
        {
            CreateMap<CreateLessonCourseRequest, LessonCourse>().ReverseMap();
            CreateMap<LessonCourse, CreatedLessonCourseResponse>().ReverseMap();

            CreateMap<DeleteLessonCourseRequest, LessonCourse>().ReverseMap();
            CreateMap<LessonCourse, DeletedLessonCourseResponse>().ReverseMap();

            CreateMap<UpdateLessonCourseRequest, LessonCourse>().ReverseMap();
            CreateMap<LessonCourse, UpdatedLessonCourseResponse>().ReverseMap();

            CreateMap<LessonCourse, GetListLessonCourseResponse>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson.Name))
                .ForMember(dest => dest.LessonTime, opt => opt.MapFrom(src => src.Lesson.LessonTime))
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src =>
                    src.Course.InstructorCourses.Any() ?
                    string.Join(", ", src.Course.InstructorCourses.Select(ic => ic.Instructor.User.FirstName + " " + ic.Instructor.User.LastName)) :
                    "No Instructor"
                ))
                .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src =>
                    src.Course.ClassroomOfCourses.Any() ?
                    string.Join(", ", src.Course.ClassroomOfCourses.Select(cc => cc.Classroom.Name)) :
                    "No Classroom"
                ))
                 .ReverseMap();

            CreateMap<Paginate<LessonCourse>, Paginate<GetListLessonCourseResponse>>()
                .ReverseMap();









        }
    }
}
