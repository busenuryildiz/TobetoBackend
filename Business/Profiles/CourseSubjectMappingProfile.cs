using AutoMapper;
using Business.DTOs.Request.CourseSubject;
using Business.DTOs.Response.CourseSubject;
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
    public class CourseSubjectMappingProfile : Profile
    {
        public CourseSubjectMappingProfile()
        {
            CreateMap<CreateCourseSubjectRequest, CourseSubject>().ReverseMap();
            CreateMap<CourseSubject, CreatedCourseSubjectResponse>().ReverseMap();

            CreateMap<DeleteCourseSubjectRequest, CourseSubject>().ReverseMap();
            CreateMap<CourseSubject, DeletedCourseSubjectResponse>().ReverseMap();

            CreateMap<UpdateCourseSubjectRequest, CourseSubject>().ReverseMap();
            CreateMap<CourseSubject, UpdatedCourseSubjectResponse>().ReverseMap();

            CreateMap<CourseSubject, GetListCourseSubjectResponse>().ReverseMap();
            CreateMap<Paginate<CourseSubject>, Paginate<GetListCourseSubjectResponse>>().ReverseMap();
        }
    }
}
