using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Paging;
using Entities.Concrete.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class StudentMappingProfile:Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<CreateStudentRequest, Student>().ReverseMap();
            CreateMap<Student, CreatedStudentResponse>().ReverseMap();

            CreateMap<DeleteStudentRequest, Student>().ReverseMap();
            CreateMap<Student, DeletedStudentResponse>().ReverseMap();

            CreateMap<UpdateStudentRequest, Student>().ReverseMap();
            CreateMap<Student, UpdatedStudentResponse>().ReverseMap();

            CreateMap<Student, GetListStudentResponse>().ReverseMap();
            CreateMap<Paginate<Student>, Paginate<GetListStudentResponse>>().ReverseMap();
        }
    }
}
