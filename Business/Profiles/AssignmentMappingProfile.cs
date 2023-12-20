using AutoMapper;
using Business.DTOs.Request.Blog;
using Business.DTOs.Response.Blog;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.Assignments;
using Business.DTOs.Response.Assignments;

namespace Business.Profiles
{
    public class AssignmentMappingProfile : Profile
    {
        public AssignmentMappingProfile()
        {
            CreateMap<CreateAssignmentRequest, Assignment>().ReverseMap();
            CreateMap<Assignment, CreatedAssignmentResponse>().ReverseMap();

            CreateMap<DeleteAssignmentRequest, Assignment>().ReverseMap();
            CreateMap<Assignment, DeletedAssignmentResponse>().ReverseMap();

            CreateMap<UpdateAssignmentRequest, Assignment>().ReverseMap();
            CreateMap<Assignment, UpdatedAssignmentResponse>().ReverseMap();

            CreateMap<Assignment, GetListAssignmentResponse>().ReverseMap();
            CreateMap<IPaginate<Assignment>, IPaginate<GetListAssignmentResponse>>().ReverseMap();
        }
    }
}
