using AutoMapper;
using Business.DTOs.Request.UserExperience;
using Business.DTOs.Response.UserExperience;
using Core.DataAccess.Paging;
using Entities.Concretes.Clients;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserExperienceExperienceMappingProfile : Profile
    {
        public UserExperienceExperienceMappingProfile()
        {
            CreateMap<CreateUserExperienceRequest, UserExperience>().ReverseMap();
            CreateMap<UserExperience, CreatedUserExperienceResponse>().ReverseMap();

            CreateMap<DeleteUserExperienceRequest, UserExperience>().ReverseMap();
            CreateMap<UserExperience, DeletedUserExperienceResponse>().ReverseMap();

            CreateMap<UpdateUserExperienceRequest, UserExperience>().ReverseMap();
            CreateMap<UserExperience, UpdatedUserExperienceResponse>().ReverseMap();

            CreateMap<UserExperience, GetListUserExperienceResponse>().ReverseMap();
            CreateMap<Paginate<UserExperience>, Paginate<GetListUserExperienceResponse>>().ReverseMap();
        }
    }
}
