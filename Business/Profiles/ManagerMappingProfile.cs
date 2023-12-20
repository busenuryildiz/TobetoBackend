using AutoMapper;
using Business.DTOs.Request.Manager;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Manager;
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
    public class ManagerMappingProfile : Profile
    {
        public ManagerMappingProfile()
        {
            //--------------------Created---------------------------------------

            CreateMap<CreateManagerRequest, Manager>().ReverseMap();
            CreateMap<CreateManagerRequest, CreateUserRequest>().ReverseMap();
            CreateMap<Manager, CreatedManagerResponse>().ReverseMap();
            CreateMap<CreateUserRequest, CreatedUserResponse>().ReverseMap();


            //-------------------Deleted----------------------------------------------

            CreateMap<DeleteManagerRequest, Manager>().ReverseMap();
            CreateMap<DeleteManagerRequest, DeleteUserRequest>().ReverseMap();
            CreateMap<Manager, DeletedManagerResponse>().ReverseMap();
            CreateMap<DeleteUserRequest, DeletedUserResponse>().ReverseMap();

            //-------------------Updated---------------------------------------------
            CreateMap<UpdateManagerRequest, Manager>().ReverseMap();
            CreateMap<UpdateManagerRequest, UpdateUserRequest>().ReverseMap();
            CreateMap<Manager, UpdatedManagerResponse>().ReverseMap();
            CreateMap<UpdateUserRequest, UpdatedUserResponse>().ReverseMap();

            //--------------------Listeleme-----------------------------------

            CreateMap<Manager, GetListManagerResponse>().ReverseMap();
            CreateMap<Paginate<Manager>, Paginate<GetListManagerResponse>>().ReverseMap();
        }
    }
}
