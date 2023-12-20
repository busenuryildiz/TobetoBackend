using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.CourseSubject;
using Business.DTOs.Response.CourseSubject;
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
    public class CourseSubjectManager : ICourseSubjectService
    {
        
        ICourseSubjectDal _courseSubjectDal;
        IMapper _mapper;
        CourseSubjectBusinessRules _businessRules;

        public CourseSubjectManager(CourseSubjectBusinessRules businessRules, ICourseSubjectDal courseSubjectDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _courseSubjectDal = courseSubjectDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseSubjectResponse> Add(CreateCourseSubjectRequest createCourseSubjectRequest)
        {
            CourseSubject courseSubject = _mapper.Map<CourseSubject>(createCourseSubjectRequest);
            CourseSubject createdCourseSubject = await _courseSubjectDal.AddAsync(courseSubject);
            CreatedCourseSubjectResponse createdCourseSubjectResponse = _mapper.Map<CreatedCourseSubjectResponse>(createdCourseSubject);
            return createdCourseSubjectResponse;
        }

        public async Task<DeletedCourseSubjectResponse> Delete(DeleteCourseSubjectRequest deleteCourseSubjectRequest)
        {
            var data = await _courseSubjectDal.GetAsync(i => i.Id == deleteCourseSubjectRequest.Id);
            _mapper.Map(deleteCourseSubjectRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _courseSubjectDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedCourseSubjectResponse>(result);
            return result2;
        }

        public async Task<CreatedCourseSubjectResponse> GetById(int id)
        {
            var result = await _courseSubjectDal.GetAsync(c => c.Id == id);
            CourseSubject mappedCourseSubject = _mapper.Map<CourseSubject>(result);

            CreatedCourseSubjectResponse createdCourseSubjectResponse = _mapper.Map<CreatedCourseSubjectResponse>(mappedCourseSubject);

            return createdCourseSubjectResponse;
        }


        public async Task<IPaginate<GetListCourseSubjectResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _courseSubjectDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCourseSubjectResponse>>(data);
            return result;
        }


        public async Task<UpdatedCourseSubjectResponse> Update(UpdateCourseSubjectRequest updateCourseSubjectRequest)
        {
            var data = await _courseSubjectDal.GetAsync(i => i.Id == updateCourseSubjectRequest.Id);
            _mapper.Map(updateCourseSubjectRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _courseSubjectDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCourseSubjectResponse>(data);
            return result;
        }
    }
}

