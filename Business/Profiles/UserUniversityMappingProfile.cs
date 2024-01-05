using Business.DTOs.Request.UserUniversity;
using Business.DTOs.Response.UserUniversity;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class UserUniversityMappingProfile:Profile
    {
        public UserUniversityMappingProfile()
        {
            CreateMap<CreateUserUniversityRequest, UserUniversity>().ReverseMap();
            CreateMap<UserUniversity, CreatedUserUniversityResponse>().ReverseMap();

            CreateMap<DeleteUserUniversityRequest, UserUniversity>().ReverseMap();
            CreateMap<UserUniversity, DeletedUserUniversityResponse>().ReverseMap();

            CreateMap<UpdateUserUniversityRequest, UserUniversity>().ReverseMap();
            CreateMap<UserUniversity, UpdatedUserUniversityResponse>().ReverseMap();

            CreateMap<UserUniversity, GetListUserUniversityResponse>().ReverseMap();
            CreateMap<Paginate<UserUniversity>, Paginate<GetListUserUniversityResponse>>().ReverseMap();
        }
    }
}
