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

            CreateMap<DeleteCourseRequest, Course>().ReverseMap();
            CreateMap<Course, DeletedCourseResponse>().ReverseMap();

            CreateMap<UpdateCourseRequest, Course>().ReverseMap();
            CreateMap<Course, UpdatedCourseResponse>().ReverseMap();

            CreateMap<Course, GetListCourseResponse>()
                .ForMember(dest => dest.InstructorName, opt =>
                    opt.MapFrom(src => $"{src.InstructorCourses.FirstOrDefault().Instructor.User.FirstName} {src.InstructorCourses.FirstOrDefault().Instructor.User.LastName}"))
                .ForMember(dest => dest.CategoryName, opt =>
                                       opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CourseLevelName, opt =>
                                                          opt.MapFrom(src => src.CourseLevel.Name))
                .ForMember(dest => dest.SoftwareLanguageName, opt =>
                                                                             opt.MapFrom(src => src.SoftwareLanguage.Name))
                .ForMember(dest => dest.ClassroomName, opt =>
                                                                                                opt.MapFrom(src => src.ClassroomOfCourses.FirstOrDefault().Classroom.Name))
                .ForMember(dest => dest.CourseSubjectName, opt =>
                                                                                                                      opt.MapFrom(src => src.CourseSubjects.FirstOrDefault().Subject.Name))

                .ReverseMap();
            CreateMap<Paginate<Course>, Paginate<GetListCourseResponse>>().ReverseMap();
        }
    }
}
