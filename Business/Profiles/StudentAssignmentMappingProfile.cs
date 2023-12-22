using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.StudentAssignment;
using Business.DTOs.Response.StudentAssignment;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Courses;

namespace Business.Profiles
{
    public class StudentAssignmentMappingProfile: Profile
    {
        public StudentAssignmentMappingProfile()
        {
            CreateMap<CreateStudentAssignmentRequest, StudentAssignment>().ReverseMap();
            CreateMap<StudentAssignment, CreatedStudentAssignmentResponse>().ReverseMap();

            CreateMap<DeleteStudentAssignmentRequest, StudentAssignment>().ReverseMap();
            CreateMap<StudentAssignment, DeletedStudentAssignmentResponse>().ReverseMap();

            CreateMap<UpdateStudentAssignmentRequest, StudentAssignment>().ReverseMap();
            CreateMap<StudentAssignment, UpdatedStudentAssignmentResponse>().ReverseMap();

            CreateMap<StudentAssignment, GetListStudentAssignmentResponse>().ReverseMap();
            CreateMap<Paginate<StudentAssignment>, Paginate<GetListStudentAssignmentResponse>>().ReverseMap();
        }
    }
}
