using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.Country;
using Business.DTOs.Response.Country;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CreateCountryRequest, Country>().ReverseMap();
            CreateMap<Country, CreatedCountryResponse>().ReverseMap();

            CreateMap<DeleteCountryRequest, Country>().ReverseMap();
            CreateMap<Country, DeletedCountryResponse>().ReverseMap();

            CreateMap<UpdateCountryRequest, Country>().ReverseMap();
            CreateMap<Country, UpdatedCountryResponse>().ReverseMap();

            CreateMap<Country, GetListCountryResponse>().ReverseMap();
            CreateMap<Paginate<Country>, Paginate<GetListCountryResponse>>().ReverseMap();
        }
    }
}
