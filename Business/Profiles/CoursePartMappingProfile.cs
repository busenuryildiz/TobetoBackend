using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.CoursePart;
using Business.DTOs.Response.CoursePart;
using Business.DTOs.Response.Lesson;
using Entities.Concretes.CoursesFolder;

namespace Business.Profiles
{
    public class CoursePartManagerMappingProfile : Profile
    {
        public CoursePartManagerMappingProfile()
        {
            CreateMap<CoursePart, CreatedCoursePartResponse>();
            CreateMap<CreateCoursePartRequest, CoursePart>();

            CreateMap<CoursePart, UpdatedCoursePartResponse>();
            CreateMap<UpdateCoursePartRequest, CoursePart>();

            CreateMap<CoursePart, GetCoursePartByIdResponse>();

            CreateMap<CoursePart, GetCoursePartByIdResponse>()
                           .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons));

            CreateMap<Lesson, CreatedLessonResponse>();
        }
    }
}
