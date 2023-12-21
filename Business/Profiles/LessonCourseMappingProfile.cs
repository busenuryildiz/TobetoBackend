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

            CreateMap<LessonCourse, GetListLessonCourseResponse>().ReverseMap();
            CreateMap<Paginate<LessonCourse>, Paginate<GetListLessonCourseResponse>>().ReverseMap();
        }
    }
}
