using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.LessonCourse;
using Business.DTOs.Response.LessonCourse;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.CoursesFolder;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class LessonCourseManager : ILessonCourseService
    {
        ILessonCourseDal _lessonCourseDal;
        IMapper _mapper;
        LessonCourseBusinessRules _businessRules;
        public LessonCourseManager(ILessonCourseDal lessonCourseDal, IMapper mapper, LessonCourseBusinessRules businessRules)
        {
            _lessonCourseDal = lessonCourseDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedLessonCourseResponse> Add(CreateLessonCourseRequest createLessonCourseRequest)
        {
            LessonCourse lessonCourse = _mapper.Map<LessonCourse>(createLessonCourseRequest);
            LessonCourse createdLessonCourse = await _lessonCourseDal.AddAsync(lessonCourse);
            CreatedLessonCourseResponse createdLessonCourseResponse = _mapper.Map<CreatedLessonCourseResponse>(createdLessonCourse);
            return createdLessonCourseResponse;
        }

        public async Task<DeletedLessonCourseResponse> Delete(DeleteLessonCourseRequest deleteLessonCourseRequest)
        {
            var data = await _lessonCourseDal.GetAsync(i => i.Id == deleteLessonCourseRequest.Id);
            _mapper.Map(deleteLessonCourseRequest, data);
            var result = await _lessonCourseDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedLessonCourseResponse>(result);
            return result2;
        }

        public async Task<CreatedLessonCourseResponse> GetById(int id)
        {
            var result = await _lessonCourseDal.GetAsync(c => c.Id == id);
            LessonCourse mappedLessonCourse = _mapper.Map<LessonCourse>(result);
            CreatedLessonCourseResponse createdLessonCourseResponse = _mapper.Map<CreatedLessonCourseResponse>(mappedLessonCourse);
            return createdLessonCourseResponse;
        }

        public async Task<IPaginate<GetListLessonCourseResponse>> GetListAsync(int size)
        {
            var data = await _lessonCourseDal.GetListAsync(
         include: query => query
             .Include(p => p.Course)
             .Include(p => p.Lesson)
             .Include(p => p.Course.InstructorCourses)
                 .ThenInclude(ic => ic.Instructor)
                 .ThenInclude(i => i.User),
                 size: size
             );
            var result = _mapper.Map<Paginate<GetListLessonCourseResponse>>(data);


            return result;
        }


        public async Task<UpdatedLessonCourseResponse> Update(UpdateLessonCourseRequest updateLessonCourseRequest)
        {
            var data = await _lessonCourseDal.GetAsync(i => i.Id == updateLessonCourseRequest.Id);
            _mapper.Map(updateLessonCourseRequest, data);
            await _lessonCourseDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedLessonCourseResponse>(data);
            return result;
        }


    }
}