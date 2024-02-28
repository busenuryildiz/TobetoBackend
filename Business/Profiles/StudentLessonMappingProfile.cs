using AutoMapper;
using Business.DTOs.Request.StudentLesson;
using Business.DTOs.Response.StudentLesson;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class StudentLessonMappingProfile:Profile
    {
        public StudentLessonMappingProfile()
        {
            CreateMap<CreateStudentLessonRequest, StudentLesson>().ReverseMap();
            CreateMap<StudentLesson, CreatedStudentLessonResponse>().ReverseMap();

            CreateMap<DeleteStudentLessonRequest, StudentLesson>().ReverseMap();
            CreateMap<StudentLesson, DeletedStudentLessonResponse>().ReverseMap();

            CreateMap<UpdateStudentLessonRequest, StudentLesson>().ReverseMap();
            CreateMap<StudentLesson, UpdatedStudentLessonResponse>().ReverseMap();

            CreateMap<StudentLesson, GetListStudentLessonResponse>().ReverseMap();
            CreateMap<Paginate<StudentLesson>, Paginate<GetListStudentLessonResponse>>().ReverseMap();

            CreateMap<IPaginate<StudentLesson>, List<GetListStudentLessonResponse>>()
               .ConvertUsing((src, dest, context) =>
               {
                   return context.Mapper.Map<List<GetListStudentLessonResponse>>(src.Items);
               });
        }
    }

}
