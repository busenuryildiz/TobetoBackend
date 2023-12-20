using AutoMapper;
using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Response.StudentCourse;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class StudentCourseMappingProfile : Profile
    {
        public StudentCourseMappingProfile()
        {
            CreateMap<CreateStudentCourseRequest, StudentCourse>();
            CreateMap<StudentCourse, CreatedStudentCourseResponse>();
            CreateMap<DeleteStudentCourseRequest, StudentCourse>();
            CreateMap<StudentCourse, DeletedStudentCourseResponse>();
            CreateMap<UpdateStudentCourseRequest, StudentCourse>();
            CreateMap<StudentCourse, UpdatedStudentCourseResponse>();
            CreateMap<StudentCourse, CreatedStudentCourseResponse>();
            CreateMap<StudentCourse, GetListStudentCourseInfoResponse>();

            // Eğer ihtiyacınız varsa diğer özelleştirmeleri buraya ekleyebilirsiniz
        }
    }
}
