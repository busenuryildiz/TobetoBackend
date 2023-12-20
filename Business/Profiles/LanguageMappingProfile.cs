using AutoMapper;
using Business.DTOs.Request.Language;
using Business.DTOs.Response.Language;
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
    public class LanguageMappingProfile : Profile
    {
        public LanguageMappingProfile()
        {
            CreateMap<CreateLanguageRequest, Language>().ReverseMap();
            CreateMap<Language, CreatedLanguageResponse>().ReverseMap();

            CreateMap<DeleteLanguageRequest, Language>().ReverseMap();
            CreateMap<Language, DeletedLanguageResponse>().ReverseMap();

            CreateMap<UpdateLanguageRequest, Language>().ReverseMap();
            CreateMap<Language, UpdatedLanguageResponse>().ReverseMap();

            CreateMap<Language, GetListLanguageResponse>().ReverseMap();
            CreateMap<Paginate<Language>, Paginate<GetListLanguageResponse>>().ReverseMap();
        }
    }
}
