using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.District;
using Business.DTOs.Response.District;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class DistrictMappingProfile : Profile
    {
        public DistrictMappingProfile()
        {
            CreateMap<CreateDistrictRequest, District>().ReverseMap();
            CreateMap<District, CreatedDistrictResponse>().ReverseMap();

            CreateMap<DeleteDistrictRequest, District>().ReverseMap();
            CreateMap<District, DeletedDistrictResponse>().ReverseMap();

            CreateMap<UpdateDistrictRequest, District>().ReverseMap();
            CreateMap<District, UpdatedDistrictResponse>().ReverseMap();

            CreateMap<District, GetListDistrictResponse>().ReverseMap();
            CreateMap<Paginate<District>, Paginate<GetListDistrictResponse>>().ReverseMap();
        }
    }
}
