using AutoMapper;
using Business.Abstracts;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.StudentAssignment;
using Business.DTOs.Response.StudentAssignment;
using Business.Rules.BusinessRules;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class StudentAssignmentManager: IStudentAssignmentService
    {
        IStudentAssignmentDal _studentAssignmentDal;
        IMapper _mapper;
        StudentAssignmentBusinessRules _businessRules;
        IStudentService _studentService;

        public StudentAssignmentManager(StudentAssignmentBusinessRules businessRules, IStudentAssignmentDal studentAssignmentDal, IMapper mapper, IStudentService studentService)
        {
            _businessRules = businessRules;
            _studentAssignmentDal = studentAssignmentDal;
            _mapper = mapper;
            _studentService = studentService;
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

        public async Task<List<GetListStudentsAssigmentsAndDates>> GetStudentAssignmentAndDateByUserId (Guid userId)
        {
            var student = _studentService.GetStudentByUserId(userId);

            var studentsAssignments = await _studentAssignmentDal.GetListAsync(predicate:sa => sa.StudentId==student.Id);

            var mappedStudentsAssignmentsAndDates = _mapper.Map<List<GetListStudentsAssigmentsAndDates>>(studentsAssignments);

            return mappedStudentsAssignmentsAndDates;
            
        }

    }
}

