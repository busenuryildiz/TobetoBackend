using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.County;
using Business.DTOs.Response.County;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class CountyMappingProfile : Profile
    {
        public CountyMappingProfile()
        {
            CreateMap<CreateCountyRequest, County>().ReverseMap();
            CreateMap<County, CreatedCountyResponse>().ReverseMap();

            CreateMap<DeleteCountyRequest, County>().ReverseMap();
            CreateMap<County, DeletedCountyResponse>().ReverseMap();

            CreateMap<UpdateCountyRequest, County>().ReverseMap();
            CreateMap<County, UpdatedCountyResponse>().ReverseMap();

            CreateMap<County, GetListCountyResponse>().ReverseMap();
            CreateMap<Paginate<County>, Paginate<GetListCountyResponse>>().ReverseMap();
        }
    }
}
