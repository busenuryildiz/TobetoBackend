using AutoMapper;
using Business.DTOs.Request.LanguageLevel;
using Business.DTOs.Response.LanguageLevel;
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
    public class LanguageLevelMappingProfile : Profile
    {
        public LanguageLevelMappingProfile()
        {
            CreateMap<CreateLanguageLevelRequest, LanguageLevel>().ReverseMap();
            CreateMap<LanguageLevel, CreatedLanguageLevelResponse>().ReverseMap();

            CreateMap<DeleteLanguageLevelRequest, LanguageLevel>().ReverseMap();
            CreateMap<LanguageLevel, DeletedLanguageLevelResponse>().ReverseMap();

            CreateMap<UpdateLanguageLevelRequest, LanguageLevel>().ReverseMap();
            CreateMap<LanguageLevel, UpdatedLanguageLevelResponse>().ReverseMap();

            CreateMap<LanguageLevel, GetListLanguageLevelResponse>().ReverseMap();
            CreateMap<Paginate<LanguageLevel>, Paginate<GetListLanguageLevelResponse>>().ReverseMap();
        }
    }
}
