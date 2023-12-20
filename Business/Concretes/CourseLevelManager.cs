using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.CourseLevel;
using Business.DTOs.Response.CourseLevel;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CourseLevelManager : ICourseLevelService
    {
        ICourseLevelDal _courseLevelDal;
        IMapper _mapper;
        CourseLevelBusinessRules _businessRules;

        public CourseLevelManager(CourseLevelBusinessRules businessRules, ICourseLevelDal courseLevelDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _courseLevelDal = courseLevelDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseLevelResponse> Add(CreateCourseLevelRequest createCourseLevelRequest)
        {
            CourseLevel courseLevel = _mapper.Map<CourseLevel>(createCourseLevelRequest);
            CourseLevel createdCourseLevel = await _courseLevelDal.AddAsync(courseLevel);
            CreatedCourseLevelResponse createdCourseLevelResponse = _mapper.Map<CreatedCourseLevelResponse>(createdCourseLevel);
            return createdCourseLevelResponse;
        }

        public async Task<DeletedCourseLevelResponse> Delete(DeleteCourseLevelRequest deleteCourseLevelRequest)
        {
            var data = await _courseLevelDal.GetAsync(i => i.Id == deleteCourseLevelRequest.Id);
            _mapper.Map(deleteCourseLevelRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _courseLevelDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedCourseLevelResponse>(result);
            return result2;
        }

        public async Task<CreatedCourseLevelResponse> GetById(int id)
        {
            var result = await _courseLevelDal.GetAsync(c => c.Id == id);
            CourseLevel mappedCourseLevel = _mapper.Map<CourseLevel>(result);

            CreatedCourseLevelResponse createdCourseLevelResponse = _mapper.Map<CreatedCourseLevelResponse>(mappedCourseLevel);

            return createdCourseLevelResponse;
        }


        public async Task<IPaginate<GetListCourseLevelResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _courseLevelDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCourseLevelResponse>>(data);
            return result;
        }


        public async Task<bool> Update(UpdateCourseLevelRequest updateCourseLevelRequest)
        {
            var data = await _courseLevelDal.GetAsync(i => i.Id == updateCourseLevelRequest.Id);
            _mapper.Map(updateCourseLevelRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _courseLevelDal.UpdateAsync(data);
            return true; // Başarı durumunu döndürün.
        }

    }
}
