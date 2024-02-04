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
using Entities.Concretes.CoursesFolder;

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
                .ForMember(dest => dest.Classroom, opt => opt.MapFrom(src => src.Course.Classroom))
                .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson.Name))
                .ForMember(dest => dest.LessonTime, opt => opt.MapFrom(src => src.Lesson.LessonTime))
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src =>
                    src.Course.InstructorCourses.Any() ?
                    string.Join(", ", src.Course.InstructorCourses.Select(ic => ic.Instructor.User.FirstName + " " + ic.Instructor.User.LastName)) :
                    "No Instructor"
                ))
                 .ReverseMap();

            CreateMap<Paginate<LessonCourse>, Paginate<GetListLessonCourseResponse>>()
                .ReverseMap();









        }
    }
}
