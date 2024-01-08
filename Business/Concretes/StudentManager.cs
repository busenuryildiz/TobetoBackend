using AutoMapper;
using Business.DTOs.Request.Student;
using Business.DTOs.Response.Student;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        IMapper _mapper;
        StudentBusinessRules _businessRules;
        public StudentManager(IStudentDal studentDal, IMapper mapper, StudentBusinessRules businessRules)
        {
            _studentDal = studentDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }
        public async Task<CreatedStudentResponse> Add(CreateStudentRequest createStudentRequest)
        {
            Student student = _mapper.Map<Student>(createStudentRequest);
            student.GenerateStudentNumber();
            await _businessRules.StudentNumberShouldBeUnique(student.StudentNumber);
            Student createdStudent = await _studentDal.AddAsync(student);
            CreatedStudentResponse createdStudentResponse = _mapper.Map<CreatedStudentResponse>(createdStudent);
            return createdStudentResponse;
        }
        public async Task<DeletedStudentResponse> Delete(DeleteStudentRequest deleteStudentRequest)
        {
            Student student = await _studentDal.GetAsync(i => i.Id == deleteStudentRequest.Id);
            student.DeletedDate = DateTime.Now;
            var deletedStudent = await _studentDal.DeleteAsync(student);
            DeletedStudentResponse deletedStudentResponse = _mapper.Map<DeletedStudentResponse>(deletedStudent);

            return deletedStudentResponse;
        }

        public async Task<CreatedStudentResponse> GetById(Guid id)
        {
            var result = await _studentDal.GetAsync(c => c.Id == id);
            Student mappedStudent = _mapper.Map<Student>(result);

            CreatedStudentResponse createdStudentResponse = _mapper.Map<CreatedStudentResponse>(mappedStudent);

            return createdStudentResponse;
        }


        public async Task<IPaginate<GetListStudentResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _studentDal.GetListAsync(
                include: u => u
                    .Include(c => c.ApplicationStudents)
                    .Include(c => c.StudentAssignments)
                    .Include(c => c.StudentCourses),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListStudentResponse>>(data);
            return result;
        }

        public async Task<UpdatedStudentResponse> Update(UpdateStudentRequest updateStudentRequest)
        {
            var data = await _studentDal.GetAsync(i => i.Id == updateStudentRequest.Id);
            _mapper.Map(updateStudentRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _studentDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedStudentResponse>(data);
            return result;
        }
    }
}

