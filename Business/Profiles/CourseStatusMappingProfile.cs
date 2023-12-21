using AutoMapper;
using Business.DTOs.Request.CourseStatus;
using Business.DTOs.Response.CourseStatus;
using Core.DataAccess.Paging;
using Entities.Concretes.Courses;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CourseStatusMappingProfile:Profile
    {
        public CourseStatusMappingProfile()
        {
            CreateMap<CreateCourseStatusRequest, CourseStatus>().ReverseMap();
            CreateMap<CourseStatus, CreatedCourseStatusResponse>().ReverseMap();

            CreateMap<DeleteCourseStatusRequest, CourseStatus>().ReverseMap();
            CreateMap<CourseStatus, DeletedCourseStatusResponse>().ReverseMap();

            CreateMap<UpdateCourseStatusRequest, CourseStatus>().ReverseMap();
            CreateMap<CourseStatus, UpdatedCourseStatusResponse>().ReverseMap();

            CreateMap<CourseStatus, GetListCourseStatusResponse>().ReverseMap();
            CreateMap<Paginate<CourseStatus>, Paginate<GetListCourseStatusResponse>>().ReverseMap();
        }
    }
}
