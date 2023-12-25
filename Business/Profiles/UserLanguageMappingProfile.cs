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
        }
    }
}
