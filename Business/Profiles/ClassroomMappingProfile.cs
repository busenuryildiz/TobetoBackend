using AutoMapper;
using Business.DTOs.Request.Classroom;
using Business.DTOs.Response.Classroom;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Clients;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ClassroomMappingProfile : Profile
    {
        public ClassroomMappingProfile()
        {
            CreateMap<CreateClassroomRequest, Classroom>().ReverseMap();
            CreateMap<Classroom, CreatedClassroomResponse>().ReverseMap();

            CreateMap<DeleteClassroomRequest, Classroom>().ReverseMap();
            CreateMap<Classroom, DeletedClassroomResponse>().ReverseMap();

            CreateMap<UpdateClassroomRequest, Classroom>().ReverseMap();
            CreateMap<Classroom, UpdatedClassroomResponse>().ReverseMap();

            CreateMap<Classroom, GetListClassroomResponse>().ReverseMap();
            CreateMap<Paginate<Classroom>, Paginate<GetListClassroomResponse>>().ReverseMap();
        }
    }
}
