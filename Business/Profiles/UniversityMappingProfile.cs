using Business.DTOs.Request.University;
using Business.DTOs.Response.University;
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
    public class UniversityMappingProfile:Profile
    {
        public UniversityMappingProfile()
        {
            CreateMap<CreateUniversityRequest, University>().ReverseMap();
            CreateMap<University, CreatedUniversityResponse>().ReverseMap();

            CreateMap<DeleteUniversityRequest, University>().ReverseMap();
            CreateMap<University, DeletedUniversityResponse>().ReverseMap();

            CreateMap<UpdateUniversityRequest, University>().ReverseMap();
            CreateMap<University, UpdatedUniversityResponse>().ReverseMap();

            CreateMap<University, GetListUniversityResponse>().ReverseMap();
            CreateMap<Paginate<University>, Paginate<GetListUniversityResponse>>().ReverseMap();
        }
    }
}
