using AutoMapper;
using Business.DTOs.Request.Student;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Student;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            //--------------------Created---------------------------------------

            CreateMap<CreateStudentRequest, Student>().ReverseMap();
            CreateMap<CreateStudentRequest, CreateUserRequest>().ReverseMap();
            CreateMap<Student, CreatedStudentResponse>().ReverseMap();
            CreateMap<CreateUserRequest, CreatedUserResponse>().ReverseMap();


            //-------------------Deleted----------------------------------------------

            CreateMap<DeleteStudentRequest, Student>().ReverseMap();
            CreateMap<DeleteStudentRequest, DeleteUserRequest>().ReverseMap();
            CreateMap<Student, DeletedStudentResponse>().ReverseMap();
            CreateMap<DeleteUserRequest, DeletedUserResponse>().ReverseMap();

            //-------------------Updated---------------------------------------------
            CreateMap<UpdateStudentRequest, Student>().ReverseMap();
            CreateMap<UpdateStudentRequest, UpdateUserRequest>().ReverseMap();
            CreateMap<Student, UpdatedStudentResponse>().ReverseMap();
            CreateMap<UpdateUserRequest, UpdatedUserResponse>().ReverseMap();

            //--------------------Listeleme-----------------------------------

            CreateMap<Student, GetListStudentResponse>().ReverseMap();
            CreateMap<Paginate<Student>, Paginate<GetListStudentResponse>>().ReverseMap();






        }
    }
}