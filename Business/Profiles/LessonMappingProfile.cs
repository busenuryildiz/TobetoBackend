using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.Lesson;
using Business.DTOs.Response.Course;
using Business.DTOs.Response.Lesson;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class LessonMappingProfile : Profile
    {
        public LessonMappingProfile()
        {
            CreateMap<CreateLessonRequest, Lesson>().ReverseMap();
            CreateMap<Lesson, CreatedLessonResponse>().ReverseMap();

            CreateMap<DeleteLessonRequest, Lesson>().ReverseMap();
            CreateMap<Lesson, DeletedLessonResponse>().ReverseMap();

            CreateMap<UpdateLessonRequest, Lesson>().ReverseMap();
            CreateMap<Lesson, UpdatedLessonResponse>().ReverseMap();

            CreateMap<Lesson, GetListLessonResponse>().ReverseMap();
            CreateMap<Paginate<Lesson>, Paginate<GetListLessonResponse>>().ReverseMap();

            CreateMap<Paginate<Course>, Paginate<GetListCourseResponse>>().ReverseMap();

            CreateMap<Lesson, GetListCourseAndLessonInfoResponse>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.CourseClassroom, opt => opt.MapFrom(src => src.Course.Classroom))
                .ForMember(dest => dest.LessonDateAndHour, opt => opt.MapFrom(src => src.LessonDateAndHour))
                .ForMember(dest => dest.InstructorFirstAndLastNames, opt => opt.MapFrom(src =>
                                         src.Course.InstructorCourses.Select(ic => new InstructorFirstAndLastName
                                                                    {
                                                                        InstructorFirstName = ic.Instructor.User.FirstName,
                                                                        InstructorLastName = ic.Instructor.User.LastName
                                                                    }).ToList()));
            //.ForMember(dest => dest.InstructorFirstName, opt => opt.MapFrom(src => src.Course.InstructorCourses.Any() ? src.Course.InstructorCourses.Select(ic => ic.Instructor.User.FirstName).ToList() : null))
            //.ForMember(dest => dest.InstructorLastName, opt => opt.MapFrom(src => src.Course.InstructorCourses.Any() ? src.Course.InstructorCourses.Select(ic => ic.Instructor.User.LastName).ToList() : null))
            //.ReverseMap();




            CreateMap<IPaginate<Lesson>, List<GetListCourseAndLessonInfoResponse>>()
              .ConvertUsing((src, dest, context) =>
              {
                  return context.Mapper.Map<List<GetListCourseAndLessonInfoResponse>>(src.Items);
              });
        }
    }
}
