using Business.DTOs.Request.SocialMediaAccount;
using Business.DTOs.Response.SocialMediaAccount;
using Core.DataAccess.Paging;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concretes;

namespace Business.Profiles
{
    public class SocialMediaAccountMappingProfile:Profile
    {
        public SocialMediaAccountMappingProfile()
        {
            CreateMap<CreateSocialMediaAccountRequest, SocialMediaAccount>().ReverseMap();
            CreateMap<SocialMediaAccount, CreatedSocialMediaAccountResponse>().ReverseMap();

            CreateMap<DeleteSocialMediaAccountRequest, SocialMediaAccount>().ReverseMap();
            CreateMap<SocialMediaAccount, DeletedSocialMediaAccountResponse>().ReverseMap();

            CreateMap<UpdateSocialMediaAccountRequest, SocialMediaAccount>().ReverseMap();
            CreateMap<SocialMediaAccount, UpdatedSocialMediaAccountResponse>().ReverseMap();

            CreateMap<SocialMediaAccount, GetListSocialMediaAccountResponse>().ReverseMap();
            CreateMap<Paginate<SocialMediaAccount>, Paginate<GetListSocialMediaAccountResponse>>().ReverseMap();
        }
    }
}
