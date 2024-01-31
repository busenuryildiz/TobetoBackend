using AutoMapper;
using Business.DTOs.Request.ClassroomOfCourse;
using Business.DTOs.Response.ClassroomOfCourse;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Clients;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ClassroomOfCourseMappingProfile : Profile
    {
        public ClassroomOfCourseMappingProfile()
        {
            CreateMap<CreateClassroomOfCourseRequest, ClassroomOfCourse>().ReverseMap();
            CreateMap<ClassroomOfCourse, CreatedClassroomOfCourseResponse>().ReverseMap();

            CreateMap<DeleteClassroomOfCourseRequest, ClassroomOfCourse>().ReverseMap();
            CreateMap<ClassroomOfCourse, DeletedClassroomOfCourseResponse>().ReverseMap();

            CreateMap<UpdateClassroomOfCourseRequest, ClassroomOfCourse>().ReverseMap();
            CreateMap<ClassroomOfCourse, UpdatedClassroomOfCourseResponse>().ReverseMap();

            CreateMap<ClassroomOfCourse, GetListClassroomOfCourseResponse>().ReverseMap();
            CreateMap<Paginate<ClassroomOfCourse>, Paginate<GetListClassroomOfCourseResponse>>().ReverseMap();
        }
    }
}
