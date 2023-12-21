using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.LessonCourse;
using Business.DTOs.Response.LessonCourse;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Courses;

namespace Business.Concretes
{
    public class LessonCourseManager: ILessonCourseService
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
            LessonCourse lessonCourse = await _lessonCourseDal.GetAsync(i => i.Id == deleteLessonCourseRequest.Id);
            lessonCourse.DeletedDate = DateTime.Now;
            var deletedLessonCourse = await _lessonCourseDal.DeleteAsync(lessonCourse);
            DeletedLessonCourseResponse deletedLessonCourseResponse = _mapper.Map<DeletedLessonCourseResponse>(deletedLessonCourse);

            return deletedLessonCourseResponse;


            //var data = await _lessonCourseDal.GetAsync(i => i.Id == deleteLessonCourseRequest.Id);
            //_mapper.Map(deleteLessonCourseRequest, data);
            //data.DeletedDate = DateTime.Now;
            //var result = await _lessonCourseDal.DeleteAsync(data);
            //var result2 = _mapper.Map<DeletedLessonCourseResponse>(result);
            //return result2;
        }

        public async Task<CreatedLessonCourseResponse> GetById(int id)
        {
            var result = await _lessonCourseDal.GetAsync(c => c.Id == id);
            LessonCourse mappedLessonCourse = _mapper.Map<LessonCourse>(result);

            CreatedLessonCourseResponse createdLessonCourseResponse = _mapper.Map<CreatedLessonCourseResponse>(mappedLessonCourse);

            return createdLessonCourseResponse;
        }


        public async Task<IPaginate<GetListLessonCourseResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _lessonCourseDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListLessonCourseResponse>>(data);
            return result;
        }


        public async Task<UpdatedLessonCourseResponse> Update(UpdateLessonCourseRequest updateLessonCourseRequest)
        {
            LessonCourse lessonCourse = await _lessonCourseDal.GetAsync(i => i.Id == updateLessonCourseRequest.Id);
            lessonCourse.UpdatedDate = DateTime.Now;
            var updatedLessonCourse = await _lessonCourseDal.UpdateAsync(lessonCourse);
            UpdatedLessonCourseResponse updatedLessonCourseResponse =
                _mapper.Map<UpdatedLessonCourseResponse>(updatedLessonCourse);

            return updatedLessonCourseResponse;



            //var data = await _lessonCourseDal.GetAsync(i => i.Id == updateLessonCourseRequest.Id);
            //_mapper.Map(updateLessonCourseRequest, data);
            //data.UpdatedDate = DateTime.Now;
            //await _lessonCourseDal.UpdateAsync(data);
            //var result = _mapper.Map<UpdatedLessonCourseResponse>(data);
            //return result;
        }
    }
}
