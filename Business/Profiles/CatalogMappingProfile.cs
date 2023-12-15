using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CatalogMappingProfile : Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<CreateCatalogRequest, Catalog>().ReverseMap();
            CreateMap<Catalog, CreatedCatalogResponse>().ReverseMap();

            CreateMap<DeleteCatalogRequest, Catalog>().ReverseMap();
            CreateMap<Catalog, DeletedCatalogResponse>().ReverseMap();

            CreateMap<UpdateCatalogRequest, Catalog>().ReverseMap();
            CreateMap<Catalog, UpdatedCatalogResponse>().ReverseMap();

            CreateMap<Catalog, GetListCatalogResponse>().ReverseMap();
            CreateMap<IPaginate<Catalog>, IPaginate<GetListCatalogResponse>>().ReverseMap();
        }
    }
}

