using Business.DTOs.Request.ApplicationStudent;
using Business.DTOs.Response.ApplicationStudent;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concretes;

namespace Business.Profiles
{
    public class ApplicationStudentMappingProfile : Profile
    {
        public ApplicationStudentMappingProfile()
        {
            CreateMap<CreateApplicationStudentRequest, ApplicationStudent>().ReverseMap();
            CreateMap<ApplicationStudent, CreatedApplicationStudentResponse>().ReverseMap();

            CreateMap<DeleteApplicationStudentRequest, ApplicationStudent>().ReverseMap();
            CreateMap<ApplicationStudent, DeletedApplicationStudentResponse>().ReverseMap();

            CreateMap<UpdateApplicationStudentRequest, ApplicationStudent>().ReverseMap();
            CreateMap<ApplicationStudent, UpdatedApplicationStudentResponse>().ReverseMap();

            CreateMap<ApplicationStudent, GetListApplicationStudentResponse>().ReverseMap();
            CreateMap<Paginate<ApplicationStudent>, Paginate<GetListApplicationStudentResponse>>().ReverseMap();
        }
    }
}
