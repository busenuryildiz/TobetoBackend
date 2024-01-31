using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Response.StudentCourse;
using Core.DataAccess.Paging;
using Entities.Concretes.CoursesFolder;
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

            CreateMap<StudentCourse, GetListStudentCourseResponse>()
                .ForMember(dest => dest.course, opt => opt.MapFrom(src => src.Course))
                .MaxDepth(5); // veya uygun bir değer



            CreateMap<UpdateStudentCourseRequest, StudentCourse>().ReverseMap();
            CreateMap<StudentCourse, UpdatedStudentCourseResponse>().ReverseMap();



            CreateMap<Paginate<StudentCourse>, Paginate<GetListStudentCourseResponse>>().ReverseMap();
        }
    }
}
