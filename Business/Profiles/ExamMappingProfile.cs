using AutoMapper;
using Business.DTOs.Request.Exam;
using Business.DTOs.Response.Exam;
using Core.DataAccess.Paging;
using Entities.Concretes.CoursesFolder;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            //--------------------Created---------------------------------------

            CreateMap<CreateExamRequest, Exam>().ReverseMap();
            CreateMap<CreateExamRequest, CreateExamRequest>().ReverseMap();
            CreateMap<Exam, CreatedExamResponse>().ReverseMap();
            CreateMap<CreateExamRequest, CreatedExamResponse>().ReverseMap();


            //-------------------Deleted----------------------------------------------

            CreateMap<DeleteExamRequest, Exam>().ReverseMap();
            CreateMap<DeleteExamRequest, DeleteExamRequest>().ReverseMap();
            CreateMap<Exam, DeletedExamResponse>().ReverseMap();
            CreateMap<DeleteExamRequest, DeletedExamResponse>().ReverseMap();

            //-------------------Updated---------------------------------------------
            CreateMap<UpdateExamRequest, Exam>().ReverseMap();
            CreateMap<UpdateExamRequest, UpdateExamRequest>().ReverseMap();
            CreateMap<Exam, UpdatedExamResponse>().ReverseMap();
            CreateMap<UpdateExamRequest, UpdatedExamResponse>().ReverseMap();

            //--------------------Listeleme-----------------------------------

            CreateMap<Exam, GetListExamResponse>().ReverseMap();
            CreateMap<Paginate<Exam>, Paginate<GetListExamResponse>>().ReverseMap();
        }
    }
}
