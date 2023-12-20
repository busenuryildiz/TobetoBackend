using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.Application;
using Business.DTOs.Response.Application;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class ApplicationMappingProfile:Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<CreateApplicationRequest, Application>().ReverseMap();
            CreateMap<Application, CreatedApplicationResponse>().ReverseMap();

            CreateMap<DeleteApplicationRequest, Application>().ReverseMap();
            CreateMap<Application, DeletedApplicationResponse>().ReverseMap();

            CreateMap<UpdateApplicationRequest, Application>().ReverseMap();
            CreateMap<Application, UpdatedApplicationResponse>().ReverseMap();

            CreateMap<Application, GetListApplicationResponse>().ReverseMap();
            CreateMap<Paginate<Application>, Paginate<GetListApplicationResponse>>().ReverseMap();
        }
    }
}
