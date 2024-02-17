using AutoMapper;
using Business.DTOs.Request.BadgeOfUser;
using Business.DTOs.Response.BadgeOfUser;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class BadgeOfUserMappingProfile : Profile
    {
        public BadgeOfUserMappingProfile()
        {
            CreateMap<CreateBadgeOfUserRequest, BadgeOfUser>().ReverseMap();
            CreateMap<BadgeOfUser, CreatedBadgeOfUserResponse>().ReverseMap();

            CreateMap<DeleteBadgeOfUserRequest, BadgeOfUser>().ReverseMap();
            CreateMap<BadgeOfUser, DeletedBadgeOfUserResponse>().ReverseMap();

            CreateMap<UpdateBadgeOfUserRequest, BadgeOfUser>().ReverseMap();
            CreateMap<BadgeOfUser, UpdatedBadgeOfUserResponse>().ReverseMap();

            CreateMap<BadgeOfUser, GetListBadgeOfUserResponse>().ReverseMap();
            CreateMap<Paginate<BadgeOfUser>, Paginate<GetListBadgeOfUserResponse>>().ReverseMap();
        }
    }
}
