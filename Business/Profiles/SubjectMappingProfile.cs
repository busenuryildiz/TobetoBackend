using AutoMapper;
using Business.DTOs.Request.Subject;
using Business.DTOs.Request.Subject;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Subject;
using Business.DTOs.Response.Subject;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SubjectMappingProfile : Profile
    {
        public SubjectMappingProfile()
        {
            CreateMap<CreateSubjectRequest, Subject>();
            CreateMap<UpdateSubjectRequest, Subject>();
            CreateMap<Subject, CreatedSubjectResponse>();
            CreateMap<Subject, UpdatedSubjectResponse>();
            CreateMap<Subject, DeletedSubjectResponse>();
            CreateMap<Subject, GetByIdSubjectResponse>();
            CreateMap<Subject, GetListSubjectInfoResponse>();
            CreateMap<Paginate<Subject>, Paginate<GetListSubjectInfoResponse>>();

        }
    }
}
