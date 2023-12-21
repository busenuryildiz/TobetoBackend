using AutoMapper;
using Business.DTOs.Request.InstructorCourse;
using Business.DTOs.Response.InstructorCourse;
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
    public class InstructorCourseMappingProfile: Profile
    {
        public InstructorCourseMappingProfile()
        {
            CreateMap<CreateInstructorCourseRequest, InstructorCourse>().ReverseMap();
            CreateMap<InstructorCourse, CreatedInstructorCourseResponse>().ReverseMap();

            CreateMap<DeleteInstructorCourseRequest, InstructorCourse>().ReverseMap();
            CreateMap<InstructorCourse, DeletedInstructorCourseResponse>().ReverseMap();

            CreateMap<UpdateInstructorCourseRequest, InstructorCourse>().ReverseMap();
            CreateMap<InstructorCourse, UpdatedInstructorCourseResponse>().ReverseMap();

            CreateMap<InstructorCourse, GetListInstructorCourseResponse>().ReverseMap();
            CreateMap<Paginate<InstructorCourse>, Paginate<GetListInstructorCourseResponse>>().ReverseMap();
        }
    }
}
