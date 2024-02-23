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
using Entities.Concretes.CoursesFolder;

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

            CreateMap<StudentAssignment, GetListStudentsAssigmentsAndDates>()
                 .ForMember(dest => dest.AssignmentId, opt => opt.MapFrom(src => src.AssignmentId))
                 .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                 .ForMember(dest => dest.AssignmentAddDate, opt => opt.MapFrom(src => src.CreatedDate));
            


            CreateMap<IPaginate<StudentAssignment>, List<GetListStudentsAssigmentsAndDates>>()
                 .ConvertUsing((src, dest, context) =>
                 {
                     return context.Mapper.Map<List<GetListStudentsAssigmentsAndDates>>(src.Items);
                 });
        }
    }
}
