using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.SoftwareLanguage;
using Business.DTOs.Response.SoftwareLanguage;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Courses;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class SoftwareLanguageMappingProfile : Profile
    {
        public SoftwareLanguageMappingProfile()
        {
            CreateMap<CreateSoftwareLanguageRequest, SoftwareLanguage>().ReverseMap();
            CreateMap<SoftwareLanguage, CreatedSoftwareLanguageResponse>().ReverseMap();

            CreateMap<DeleteSoftwareLanguageRequest, SoftwareLanguage>().ReverseMap();
            CreateMap<SoftwareLanguage, DeletedSoftwareLanguageResponse>().ReverseMap();

            CreateMap<UpdateSoftwareLanguageRequest, SoftwareLanguage>().ReverseMap();
            CreateMap<SoftwareLanguage, UpdatedSoftwareLanguageResponse>().ReverseMap();

            CreateMap<SoftwareLanguage, GetListSoftwareLanguageResponse>().ReverseMap();
            CreateMap<Paginate<SoftwareLanguage>, Paginate<GetListSoftwareLanguageResponse>>().ReverseMap();
        }
    }
}
