using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.InstructorCourse;
using Business.DTOs.Response.InstructorCourse;
using Business.Rules.BusinessRules;
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

    public class InstructorCourseManager : IInstructorCourseService
    {
        IInstructorCourseDal _InstructorCourseDal;
        IMapper _mapper;
        InstructorCourseBusinessRules _businessRules;

        public InstructorCourseManager(InstructorCourseBusinessRules businessRules, IInstructorCourseDal InstructorCourseDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _InstructorCourseDal = InstructorCourseDal;
            _mapper = mapper;
        }

        public async Task<CreatedInstructorCourseResponse> Add(CreateInstructorCourseRequest createInstructorCourseRequest)
        {
            InstructorCourse InstructorCourse = _mapper.Map<InstructorCourse>(createInstructorCourseRequest);
            InstructorCourse createdInstructorCourse = await _InstructorCourseDal.AddAsync(InstructorCourse);
            CreatedInstructorCourseResponse createdInstructorCourseResponse = _mapper.Map<CreatedInstructorCourseResponse>(createdInstructorCourse);
            return createdInstructorCourseResponse;
        }

        public async Task<DeletedInstructorCourseResponse> Delete(DeleteInstructorCourseRequest deleteInstructorCourseRequest)
        {
            var data = await _InstructorCourseDal.GetAsync(i => i.Id == deleteInstructorCourseRequest.Id);
            _mapper.Map(deleteInstructorCourseRequest, data);
            var result = await _InstructorCourseDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedInstructorCourseResponse>(result);
            return result2;
        }

        public async Task<CreatedInstructorCourseResponse> GetById(int id)
        {
            var result = await _InstructorCourseDal.GetAsync(c => c.Id == id);
            InstructorCourse mappedInstructorCourse = _mapper.Map<InstructorCourse>(result);
            CreatedInstructorCourseResponse createdInstructorCourseResponse = _mapper.Map<CreatedInstructorCourseResponse>(mappedInstructorCourse);
            return createdInstructorCourseResponse;
        }


        public async Task<IPaginate<GetListInstructorCourseResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _InstructorCourseDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListInstructorCourseResponse>>(data);
            return result;
        }


        public async Task<UpdatedInstructorCourseResponse> Update(UpdateInstructorCourseRequest updateInstructorCourseRequest)
        {
            var data = await _InstructorCourseDal.GetAsync(i => i.Id == updateInstructorCourseRequest.Id);
            _mapper.Map(updateInstructorCourseRequest, data);
            await _InstructorCourseDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedInstructorCourseResponse>(data);
            return result;
        }
    }

}
