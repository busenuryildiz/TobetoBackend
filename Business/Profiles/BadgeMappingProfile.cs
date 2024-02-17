using AutoMapper;
using Business.DTOs.Request.Badge;
using Business.DTOs.Response.Badge;
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
    public class BadgeMappingProfile : Profile
    {
        public BadgeMappingProfile()
        {
            CreateMap<CreateBadgeRequest, Badge>().ReverseMap();
            CreateMap<Badge, CreatedBadgeResponse>().ReverseMap();

            CreateMap<DeleteBadgeRequest, Badge>().ReverseMap();
            CreateMap<Badge, DeletedBadgeResponse>().ReverseMap();

            CreateMap<UpdateBadgeRequest, Badge>().ReverseMap();
            CreateMap<Badge, UpdatedBadgeResponse>().ReverseMap();

            CreateMap<Badge, GetListBadgeResponse>().ReverseMap();
            CreateMap<Paginate<Badge>, Paginate<GetListBadgeResponse>>().ReverseMap();
        }
    }
}
