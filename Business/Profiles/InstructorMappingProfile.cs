using AutoMapper;
using Business.DTOs.Request.Instructor;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Instructor;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            //--------------------Created---------------------------------------

            CreateMap<CreateInstructorRequest, Instructor>().ReverseMap();
            CreateMap<CreateInstructorRequest, CreateUserRequest>().ReverseMap();
            CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
            CreateMap<CreateUserRequest, CreatedUserResponse>().ReverseMap();


            //-------------------Deleted----------------------------------------------

            CreateMap<DeleteInstructorRequest, Instructor>().ReverseMap();
            CreateMap<DeleteInstructorRequest, DeleteUserRequest>().ReverseMap();
            CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();
            CreateMap<DeleteUserRequest, DeletedUserResponse>().ReverseMap();

            //-------------------Updated---------------------------------------------
            CreateMap<UpdateInstructorRequest, Instructor>().ReverseMap();
            CreateMap<UpdateInstructorRequest, UpdateUserRequest>().ReverseMap();
            CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();
            CreateMap<UpdateUserRequest, UpdatedUserResponse>().ReverseMap();

            //--------------------Listeleme-----------------------------------

            CreateMap<Instructor, GetListInstructorResponse>().ReverseMap();
            CreateMap<Paginate<Instructor>, Paginate<GetListInstructorResponse>>().ReverseMap();
        }
    }
}
