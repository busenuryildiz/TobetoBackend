using AutoMapper;
using Business.DTOs.Request.Blog;
using Business.DTOs.Request.Skill;
using Business.DTOs.Response.Blog;
using Business.DTOs.Response.Skill;
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
    public class SkillMappingProfile:Profile
    {
        public SkillMappingProfile()
        {
            CreateMap<CreateSkillRequest, Skill>().ReverseMap();
            CreateMap<Skill, CreatedSkillResponse>().ReverseMap();

            CreateMap<DeleteSkillRequest, Skill>().ReverseMap();
            CreateMap<Skill, DeletedSkillResponse>().ReverseMap();

            CreateMap<UpdateSkillRequest, Skill>().ReverseMap();
            CreateMap<Skill, UpdatedSkillResponse>().ReverseMap();

            CreateMap<Skill, GetListSkillResponse>().ReverseMap();
            CreateMap<Paginate<Skill>, Paginate<GetListSkillResponse>>().ReverseMap();
        }
    }
}
