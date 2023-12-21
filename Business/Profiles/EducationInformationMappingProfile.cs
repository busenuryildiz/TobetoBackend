using AutoMapper;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.EducationInformation;
using Business.DTOs.Response.EducationInformation;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class EducationInformationMappingProfile : Profile
    {
        public EducationInformationMappingProfile()
        {
            CreateMap<CreateEducationInformationRequest, EducationInformation>().ReverseMap();
            CreateMap<EducationInformation, CreatedEducationInformationResponse>().ReverseMap();

            CreateMap<DeleteEducationInformationRequest, EducationInformation>().ReverseMap();
            CreateMap<EducationInformation, DeletedEducationInformationResponse>().ReverseMap();

            CreateMap<UpdateEducationInformationRequest, EducationInformation>().ReverseMap();
            CreateMap<EducationInformation, UpdatedEducationInformationResponse>().ReverseMap();

            CreateMap<EducationInformation, GetListEducationInformationResponse>().ReverseMap();
            CreateMap<Paginate<EducationInformation>, Paginate<GetListEducationInformationResponse>>().ReverseMap();
        }
    }
}
