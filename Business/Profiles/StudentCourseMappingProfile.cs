using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Response.StudentCourse;
using Business.DTOs.Response.StudentCourse;
using Core.DataAccess.Paging;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business.Profiles
{
    public class StudentCourseMappingProfile : Profile
    {
        public StudentCourseMappingProfile()
        {
            CreateMap<CreateStudentCourseRequest, StudentCourse>().ReverseMap();
            CreateMap<StudentCourse, CreatedStudentCourseResponse>().ReverseMap();

            CreateMap<DeleteStudentCourseRequest, StudentCourse>().ReverseMap();
            CreateMap<StudentCourse, DeletedStudentCourseResponse>().ReverseMap();

            CreateMap<UpdateStudentCourseRequest, StudentCourse>().ReverseMap();
            CreateMap<StudentCourse, UpdatedStudentCourseResponse>().ReverseMap();

            CreateMap<StudentCourse, GetListStudentCourseResponse>().ReverseMap();
            CreateMap<Paginate<StudentCourse>, Paginate<GetListStudentCourseResponse>>().ReverseMap();
        }
    }
}
