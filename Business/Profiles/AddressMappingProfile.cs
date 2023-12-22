using AutoMapper;
using Business.DTOs.Request.Address;
using Business.DTOs.Response.Address;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<CreateAddressRequest, Address>().ReverseMap();
            CreateMap<Address, CreatedAddressResponse>().ReverseMap();

            CreateMap<DeleteAddressRequest, Address>().ReverseMap();
            CreateMap<Address, DeletedAddressResponse>().ReverseMap();

            CreateMap<UpdateAddressRequest, Address>().ReverseMap();
            CreateMap<Address, UpdatedAddressResponse>().ReverseMap();

            CreateMap<Address, GetListAddressResponse>().ReverseMap();
            CreateMap<Paginate<Address>, Paginate<GetListAddressResponse>>().ReverseMap();
        }
    }
}
