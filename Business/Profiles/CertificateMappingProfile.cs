using AutoMapper;
using Business.DTOs.Request.Certificate;
using Business.DTOs.Response.Certificate;
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
    public class CertificateMappingProfile : Profile
    {
        public CertificateMappingProfile()
        {
            CreateMap<CreateCertificateRequest, Certificate>().ReverseMap();
            CreateMap<Certificate, CreatedCertificateResponse>().ReverseMap();

            CreateMap<DeleteCertificateRequest, Certificate>().ReverseMap();
            CreateMap<Certificate, DeletedCertificateResponse>().ReverseMap();

            CreateMap<UpdateCertificateRequest, Certificate>().ReverseMap();
            CreateMap<Certificate, UpdatedCertificateResponse>().ReverseMap();

            CreateMap<Certificate, GetListCertificateResponse>().ReverseMap();
            CreateMap<Paginate<Certificate>, Paginate<GetListCertificateResponse>>().ReverseMap();
        }
    }
}
