using AutoMapper;
using Business.DTOs.Request.Subject;
using Business.DTOs.Request.Subject;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Subject;
using Business.DTOs.Response.Subject;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SubjectMappingProfile : Profile
    {
        public SubjectMappingProfile()
        {
            //--------------------Created---------------------------------------

            CreateMap<CreateSubjectRequest, Subject>().ReverseMap();
            CreateMap<CreateSubjectRequest, CreateUserRequest>().ReverseMap();
            CreateMap<Subject, CreatedSubjectResponse>().ReverseMap();
            CreateMap<CreateUserRequest, CreatedUserResponse>().ReverseMap();


            //-------------------Deleted----------------------------------------------

            CreateMap<DeleteSubjectRequest, Subject>().ReverseMap();
            CreateMap<DeleteSubjectRequest, DeleteUserRequest>().ReverseMap();
            CreateMap<Subject, DeletedSubjectResponse>().ReverseMap();
            CreateMap<DeleteUserRequest, DeletedUserResponse>().ReverseMap();

            //-------------------Updated---------------------------------------------
            CreateMap<UpdateSubjectRequest, Subject>().ReverseMap();
            CreateMap<UpdateSubjectRequest, UpdateUserRequest>().ReverseMap();
            CreateMap<Subject, UpdatedSubjectResponse>().ReverseMap();
            CreateMap<UpdateUserRequest, UpdatedUserResponse>().ReverseMap();

            //--------------------Listeleme-----------------------------------

            CreateMap<Subject, GetListSubjectResponse>().ReverseMap();
            CreateMap<Paginate<Subject>, Paginate<GetListSubjectResponse>>().ReverseMap();
        }
    }
}
