using AutoMapper;
using Business.DTOs.Request.user;
using Business.DTOs.Response.user;
using Core.DataAccess.Paging;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{ 
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<User, CreatedUserResponse>().ReverseMap();

            //CreateMap<DeleteUserRequest, User>().ReverseMap();
            //CreateMap<User, DeletedUserResponse>().ReverseMap();

            //CreateMap<UpdateUserRequest, User>().ReverseMap();
            //CreateMap<User, UpdatedUserResponse>().ReverseMap();

            //CreateMap<User, GetListUserResponse>().ReverseMap();
            //CreateMap<Paginate<User>, Paginate<GetListUserResponse>>().ReverseMap();
        }
    }
}
