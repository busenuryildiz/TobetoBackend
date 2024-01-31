using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Request.Lesson;
using Business.DTOs.Response.Lesson;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class LessonMappingProfile : Profile
    {
        public LessonMappingProfile()
        {
            CreateMap<CreateLessonRequest, Lesson>().ReverseMap();
            CreateMap<Lesson, CreatedLessonResponse>().ReverseMap();

            CreateMap<DeleteLessonRequest, Lesson>().ReverseMap();
            CreateMap<Lesson, DeletedLessonResponse>().ReverseMap();

            CreateMap<UpdateLessonRequest, Lesson>().ReverseMap();
            CreateMap<Lesson, UpdatedLessonResponse>().ReverseMap();

            CreateMap<Lesson, GetListLessonResponse>().ReverseMap();
            CreateMap<Paginate<Lesson>, Paginate<GetListLessonResponse>>().ReverseMap();
        }
    }
}
