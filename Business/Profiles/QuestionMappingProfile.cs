using AutoMapper;
using Business.DTOs.Request.Question;
using Business.DTOs.Response.Question;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<CreateQuestionRequest, Question>();
            CreateMap<Question, CreatedQuestionResponse>();
            CreateMap<Question, UpdatedQuestionResponse>();
            CreateMap<Question, DeletedQuestionResponse>();
            CreateMap<Question, GetListQuestionResponse>();
            CreateMap<CreateQuestionRequest, Question>();
            CreateMap<Question, CreatedQuestionResponse>();
            CreateMap<Question, GetListQuestionResponse>();
        }
    }
}
