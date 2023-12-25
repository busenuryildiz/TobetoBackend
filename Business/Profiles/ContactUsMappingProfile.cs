using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.ContactUs;
using Business.DTOs.Response.ContactUs;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class ContactUsMappingProfile : Profile
    {
        public ContactUsMappingProfile()
        {
            CreateMap<CreateContactUsRequest, ContactUs>().ReverseMap();
            CreateMap<ContactUs, CreatedContactUsResponse>().ReverseMap();

            CreateMap<DeleteContactUsRequest, ContactUs>().ReverseMap();
            CreateMap<ContactUs, DeletedContactUsResponse>().ReverseMap();

            CreateMap<UpdateContactUsRequest, ContactUs>().ReverseMap();
            CreateMap<ContactUs, UpdatedContactUsResponse>().ReverseMap();

            CreateMap<ContactUs, GetListContactUsResponse>().ReverseMap();
            CreateMap<Paginate<ContactUs>, Paginate<GetListContactUsResponse>>().ReverseMap();
        }
    }
}
