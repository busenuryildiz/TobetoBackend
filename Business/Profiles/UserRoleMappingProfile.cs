using Business.DTOs.Request.UserRole;
using Business.DTOs.Response.UserRole;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concretes;

namespace Business.Profiles
{
    public class UserRoleMappingProfile:Profile
    {
        public UserRoleMappingProfile()
        {
            CreateMap<CreateUserRoleRequest, UserRole>().ReverseMap();
            CreateMap<UserRole, CreatedUserRoleResponse>().ReverseMap();

            CreateMap<DeleteUserRoleRequest, UserRole>().ReverseMap();
            CreateMap<UserRole, DeletedUserRoleResponse>().ReverseMap();

            CreateMap<UpdateUserRoleRequest, UserRole>().ReverseMap();
            CreateMap<UserRole, UpdatedUserRoleResponse>().ReverseMap();

            CreateMap<UserRole, GetListUserRoleResponse>().ReverseMap();
            CreateMap<Paginate<UserRole>, Paginate<GetListUserRoleResponse>>().ReverseMap();
        }
    }
}
