using AutoMapper;
using Business.Abstracts;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.StudentAssignment;
using Business.DTOs.Response.StudentAssignment;

namespace Business.Concretes
{
    public class StudentAssignmentManager: IStudentAssignmentService
    {
        IStudentAssignmentDal _studentAssignmentDal;
        IMapper _mapper;
        StudentAssignmentBusinessRules _businessRules;

        public StudentAssignmentManager(StudentAssignmentBusinessRules businessRules, IStudentAssignmentDal studentAssignmentDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _studentAssignmentDal = studentAssignmentDal;
            _mapper = mapper;
        }

        public async Task<CreatedStudentAssignmentResponse> Add(CreateStudentAssignmentRequest createStudentAssignmentRequest)
        {
            StudentAssignment studentAssignment = _mapper.Map<StudentAssignment>(createStudentAssignmentRequest);
            StudentAssignment createdStudentAssignment = await _studentAssignmentDal.AddAsync(studentAssignment);
            CreatedStudentAssignmentResponse createdStudentAssignmentResponse = _mapper.Map<CreatedStudentAssignmentResponse>(createdStudentAssignment);
            return createdStudentAssignmentResponse;
        }

        public async Task<DeletedStudentAssignmentResponse> Delete(DeleteStudentAssignmentRequest deleteStudentAssignmentRequest)
        {
            var data = await _studentAssignmentDal.GetAsync(i => i.Id == deleteStudentAssignmentRequest.Id);
            _mapper.Map(deleteStudentAssignmentRequest, data);
            var result = await _studentAssignmentDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedStudentAssignmentResponse>(result);
            return result2;
        }

        public async Task<CreatedStudentAssignmentResponse> GetById(int id)
        {
            var result = await _studentAssignmentDal.GetAsync(c => c.Id == id);
            StudentAssignment mappedStudentAssignment = _mapper.Map<StudentAssignment>(result);
            CreatedStudentAssignmentResponse createdStudentAssignmentResponse = _mapper.Map<CreatedStudentAssignmentResponse>(mappedStudentAssignment);
            return createdStudentAssignmentResponse;
        }


        public async Task<IPaginate<GetListStudentAssignmentResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _studentAssignmentDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListStudentAssignmentResponse>>(data);
            return result;
        }


        public async Task<UpdatedStudentAssignmentResponse> Update(UpdateStudentAssignmentRequest updateStudentAssignmentRequest)
        {
            var data = await _studentAssignmentDal.GetAsync(i => i.Id == updateStudentAssignmentRequest.Id);
            _mapper.Map(updateStudentAssignmentRequest, data);
            await _studentAssignmentDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedStudentAssignmentResponse>(data);
            return result;
        }
    }
}

