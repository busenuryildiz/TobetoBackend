using AutoMapper;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Paging;
using Entities.Concrete.Course;
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
            CreateMap<CreateExamRequest, Exam>().ReverseMap();
            CreateMap<Exam, CreatedExamResponse>().ReverseMap();

            CreateMap<DeleteExamRequest, Exam>().ReverseMap();
            CreateMap<Exam, DeletedExamResponse>().ReverseMap();

            CreateMap<UpdateExamRequest, Exam>().ReverseMap();
            CreateMap<Exam, UpdatedExamResponse>().ReverseMap();

            CreateMap<Exam, GetListExamResponse>().ReverseMap();
            CreateMap<IPaginate<Exam>, IPaginate<GetListExamResponse>>().ReverseMap();
        }
    }
}
