using AutoMapper;
using Business.DTOs.Request.Payment;
using Business.DTOs.Response.Payment;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.CoursesFolder;

namespace Business.Profiles
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<CreatePaymentRequest, Payment>().ReverseMap();
            CreateMap<Payment, CreatedPaymentResponse>().ReverseMap();

            CreateMap<DeletePaymentRequest, Payment>().ReverseMap();
            CreateMap<Payment, DeletedPaymentResponse>().ReverseMap();

            CreateMap<UpdatePaymentRequest, Payment>().ReverseMap();
            CreateMap<Payment, UpdatedPaymentResponse>().ReverseMap();

            CreateMap<Payment, GetListPaymentResponse>().ReverseMap();
            CreateMap<Paginate<Payment>, Paginate<GetListPaymentResponse>>().ReverseMap();
        }
    }
}
