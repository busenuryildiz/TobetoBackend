using AutoMapper;
using Core.DataAccess.Paging;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.User;
using Business.DTOs.Response.User;

namespace Business.Profiles
{ 
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<User, CreatedUserResponse>().ReverseMap();

            CreateMap<DeleteUserRequest, User>().ReverseMap();
            CreateMap<User, DeletedUserResponse>().ReverseMap();

            CreateMap<UpdateUserRequest, User>().ReverseMap();
            CreateMap<User, UpdatedUserResponse>().ReverseMap();

            CreateMap<User, GetListUserResponse>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));
            //CreateMap<Paginate<User>, Paginate<GetListUserResponse>>().ReverseMap();
            CreateMap<Paginate<User>, Paginate<GetListUserResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)).ReverseMap();
        }
    }
}
