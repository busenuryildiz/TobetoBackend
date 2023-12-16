using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Paging;
using Entities.Concrete.Course;
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
            CreateMap<CreateCatalogRequest, SoftwareLanguage>().ReverseMap();
            CreateMap<SoftwareLanguage, CreatedCatalogResponse>().ReverseMap();

            CreateMap<DeleteCatalogRequest, SoftwareLanguage>().ReverseMap();
            CreateMap<SoftwareLanguage, DeletedCatalogResponse>().ReverseMap();

            CreateMap<UpdateCatalogRequest, SoftwareLanguage>().ReverseMap();
            CreateMap<SoftwareLanguage, UpdatedCatalogResponse>().ReverseMap();

            CreateMap<SoftwareLanguage, GetListCatalogResponse>().ReverseMap();
            CreateMap<IPaginate<SoftwareLanguage>, IPaginate<GetListCatalogResponse>>().ReverseMap();
        }
    }
}

