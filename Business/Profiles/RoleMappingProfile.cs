using AutoMapper;
using Business.DTOs.Request.Role;
using Business.DTOs.Response.Role;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class RoleMappingProfile :Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<CreateRoleRequest, Role>().ReverseMap();
            CreateMap<Role, CreatedRoleResponse>().ReverseMap();

            CreateMap<DeleteRoleRequest, Role>().ReverseMap();
            CreateMap<Role, DeletedRoleResponse>().ReverseMap();

            CreateMap<UpdateRoleRequest, Role>().ReverseMap();
            CreateMap<Role, UpdatedRoleResponse>().ReverseMap();

            CreateMap<Role, GetListRoleResponse>().ReverseMap();
            CreateMap<Paginate<Role>, Paginate<GetListRoleResponse>>().ReverseMap();
        }
    }
}
