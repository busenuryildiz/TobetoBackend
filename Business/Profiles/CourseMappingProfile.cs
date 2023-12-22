using AutoMapper;
using Business.DTOs.Request.Course;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Course;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using Entities.Concretes.Clients;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CourseMappingProfile:Profile 
    {
        public CourseMappingProfile()
        {
            CreateMap<CreateCourseRequest, Course>().ReverseMap();
            CreateMap<Course, CreatedCourseResponse>().ReverseMap();

            CreateMap<DeleteCourseRequest, Course>().ReverseMap();
            CreateMap<Course, DeletedCourseResponse>().ReverseMap();

            CreateMap<UpdateCourseRequest, Course>().ReverseMap();
            CreateMap<Course, UpdatedCourseResponse>().ReverseMap();

            CreateMap<Course, GetListCourseResponse>().ReverseMap();
            CreateMap<Paginate<Course>, Paginate<GetListCourseResponse>>().ReverseMap();
        }
    }
}
