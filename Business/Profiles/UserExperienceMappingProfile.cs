using AutoMapper;
using Business.DTOs.Request.UserExperience;
using Business.DTOs.Response.UserExperience;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserExperienceMappingProfile : Profile
    {
        public UserExperienceMappingProfile()
        {
            CreateMap<CreateUserExperienceRequest, UserExperience>();
            CreateMap<UpdateUserExperienceRequest, UserExperience>();
            CreateMap<UserExperience, GetListUserExperienceResponse>();
            CreateMap<UserExperience, CreatedUserExperienceResponse>();
            CreateMap<UserExperience, UpdatedUserExperienceResponse>();
            CreateMap<UserExperience, DeletedUserExperienceResponse>();
        }
    }
}
