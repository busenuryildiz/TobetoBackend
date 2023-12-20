using AutoMapper;
using Business.DTOs.Request.Exam;
using Business.DTOs.Response.Exam;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            // Request DTO to Entity
            CreateMap<CreateExamRequest, Exam>();
            CreateMap<UpdateExamRequest, Exam>();

            // Entity to Response DTO
            CreateMap<Exam, CreatedExamResponse>();
            CreateMap<Exam, DeletedExamResponse>();
            CreateMap<Exam, UpdatedExamResponse>();
            CreateMap<Exam, GetByIdExamResponse>();
            CreateMap<Exam, GetListExamInfoResponse>();
        }
    }
}
