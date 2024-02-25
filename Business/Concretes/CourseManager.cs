﻿using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Course;
using Business.DTOs.Response.Blog;
using Business.DTOs.Response.Course;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        IMapper _mapper;
        CourseBusinessRules _businessRules;

        public CourseManager(CourseBusinessRules businessRules, ICourseDal courseDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _courseDal = courseDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
        {
            Course course = _mapper.Map<Course>(createCourseRequest);
            Course createdCourse = await _courseDal.AddAsync(course);
            CreatedCourseResponse createdCourseResponse = _mapper.Map<CreatedCourseResponse>(createdCourse);
            return createdCourseResponse;
        }

        public async Task<DeletedCourseResponse> Delete(DeleteCourseRequest deleteCourseRequest)
        {
            var data = await _courseDal.GetAsync(i => i.Id == deleteCourseRequest.Id);
            _mapper.Map(deleteCourseRequest, data);
            var result = await _courseDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedCourseResponse>(result);
            return result2;
        }

        public async Task<CreatedCourseResponse> GetById(int id)
        {
            var result = await _courseDal.GetAsync(c => c.Id == id);
            Course mappedCourse = _mapper.Map<Course>(result);
            CreatedCourseResponse createdCourseResponse = _mapper.Map<CreatedCourseResponse>(mappedCourse);
            return createdCourseResponse;
        }

        public async Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _courseDal.GetListAsync(
                include: u => u
                    .Include(u => u.Category)
                    .Include(u => u.Assignments)
                    .Include(u => u.Exams)
                    .Include(u => u.CourseLevel)
                    //.Include(u => u.LessonCourses)
                    .Include(u => u.SoftwareLanguage)
                    .Include(c => c.InstructorCourses)
                    .ThenInclude(ic => ic.Instructor)
                    .ThenInclude(i => i.User),

        index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCourseResponse>>(data);
            return result;
        }

        public async Task<UpdatedCourseResponse> Update(UpdateCourseRequest updateCourseRequest)
        {
            var data = await _courseDal.GetAsync(i => i.Id == updateCourseRequest.Id);
            _mapper.Map(updateCourseRequest, data);
            await _courseDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCourseResponse>(data);
            return result;
        }
    }
}
