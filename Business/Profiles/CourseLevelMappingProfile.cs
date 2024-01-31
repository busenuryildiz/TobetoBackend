using AutoMapper;
using Business.DTOs.Request.CourseLevel;
using Business.DTOs.Response.CourseLevel;
using Core.DataAccess.Paging;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CourseLevelMappingProfile : Profile
    {
        public CourseLevelMappingProfile()
        {
            CreateMap<CreateCourseLevelRequest, CourseLevel>().ReverseMap();
            CreateMap<CourseLevel, CreatedCourseLevelResponse>().ReverseMap();

            CreateMap<DeleteCourseLevelRequest, CourseLevel>().ReverseMap();
            CreateMap<CourseLevel, DeletedCourseLevelResponse>().ReverseMap();

            CreateMap<UpdateCourseLevelRequest, CourseLevel>().ReverseMap();
            CreateMap<CourseLevel, UpdatedCourseLevelResponse>().ReverseMap();

            CreateMap<CourseLevel, GetListCourseLevelResponse>().ReverseMap();
            CreateMap<Paginate<CourseLevel>, Paginate<GetListCourseLevelResponse>>().ReverseMap();
        }
    }
}
