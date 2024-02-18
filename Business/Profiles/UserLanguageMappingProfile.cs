using AutoMapper;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.UserLanguage;
using Business.DTOs.Response.UserLanguage;
using Entities.Concretes.Profiles;
using Business.DTOs.Response.User;
using Entities.Concretes.Clients;
using Business.DTOs.Response.Student;

namespace Business.Profiles
{
    public class UserLanguageMappingProfile : Profile
    {
        public UserLanguageMappingProfile()
        {
            CreateMap<CreateUserLanguageRequest, UserLanguage>().ReverseMap();
            CreateMap<UserLanguage, CreatedUserLanguageResponse>().ReverseMap();

            CreateMap<DeleteUserLanguageRequest, UserLanguage>().ReverseMap();
            CreateMap<UserLanguage, DeletedUserLanguageResponse>().ReverseMap();

            CreateMap<UpdateUserLanguageRequest, UserLanguage>().ReverseMap();
            CreateMap<UserLanguage, UpdatedUserLanguageResponse>().ReverseMap();

            CreateMap<UserLanguage, GetListUserLanguageResponse>().ReverseMap();
            CreateMap<Paginate<UserLanguage>, Paginate<GetListUserLanguageResponse>>().ReverseMap();

            CreateMap<UserLanguage, GetUserLanguageAndLevelResponse>()
                 .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Language.Name))
                 .ForMember(dest => dest.LanguageLevelName, opt => opt.MapFrom(src => src.LanguageLevel.Name));

            CreateMap<Paginate<UserLanguage>, Paginate<GetUserLanguageAndLevelResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

        }
    }
}
