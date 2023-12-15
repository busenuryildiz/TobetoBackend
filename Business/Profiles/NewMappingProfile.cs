using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class NewMappingProfile : Profile
    {
        public NewMappingProfile()
        {
            CreateMap<CreateNewRequest, New>().ReverseMap();
            CreateMap<New, CreatedNewResponse>().ReverseMap();

            CreateMap<DeleteNewRequest, New>().ReverseMap();
            CreateMap<New, DeletedNewResponse>().ReverseMap();

            CreateMap<UpdateNewRequest, New>().ReverseMap();
            CreateMap<New, UpdatedNewResponse>().ReverseMap();

            CreateMap<New, GetListNewResponse>().ReverseMap();
            CreateMap<IPaginate<New>, IPaginate<GetListNewResponse>>().ReverseMap();
        }
    }
}
