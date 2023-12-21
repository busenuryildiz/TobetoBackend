using AutoMapper;
using Business.DTOs.Request.Option;
using Business.DTOs.Response.Option;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class OptionMappingProfile : Profile
    {
        public OptionMappingProfile()
        {
            CreateMap<Option, GetListOptionResponse>().ReverseMap();
            CreateMap<Option, CreatedOptionResponse>().ReverseMap();
            CreateMap<Option, UpdatedOptionResponse>().ReverseMap();
            CreateMap<Option, DeletedOptionResponse>().ReverseMap();

            CreateMap<CreateOptionRequest, Option>();
            CreateMap<UpdateOptionRequest, Option>();
        }
    }
}
