using AutoMapper;
using Business.DTOs.Request.City;
using Business.DTOs.Response.City;
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
    public class CityMappingProfile:Profile
    {
        public CityMappingProfile()
        {
            CreateMap<CreateCityRequest, City>().ReverseMap();
            CreateMap<City, CreatedCityResponse>().ReverseMap();

            CreateMap<DeleteCityRequest, City>().ReverseMap();
            CreateMap<City, DeletedCityResponse>().ReverseMap();

            CreateMap<UpdateCityRequest, City>().ReverseMap();
            CreateMap<City, UpdatedCityResponse>().ReverseMap();

            CreateMap<City, GetListCityResponse>().ReverseMap();
            CreateMap<Paginate<City>, Paginate<GetListCityResponse>>().ReverseMap();
        }
    }
}
