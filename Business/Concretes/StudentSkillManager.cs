using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.StudentSkill;
using Business.DTOs.Response.Student;
using Business.DTOs.Response.StudentSkill;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class StudentSkillManager:IStudentSkillService
    {
        IStudentSkillDal _studentSkillDal;
        IMapper _mapper;
        StudentSkillBusinessRules _businessRules;
        IStudentService _studentService;

        public StudentSkillManager(StudentSkillBusinessRules businessRules, IStudentSkillDal studentSkillDal, IMapper mapper, IStudentService studentService)
        {
            _businessRules = businessRules;
            _studentSkillDal = studentSkillDal;
            _mapper = mapper;
            _studentService = studentService;
        }

        public async Task<CreatedStudentSkillResponse> Add(CreateStudentSkillRequest createStudentSkillRequest)
        {
            StudentSkill studentSkill = _mapper.Map<StudentSkill>(createStudentSkillRequest);
            StudentSkill createdStudentSkill = await _studentSkillDal.AddAsync(studentSkill);
            CreatedStudentSkillResponse createdStudentSkillResponse = _mapper.Map<CreatedStudentSkillResponse>(createdStudentSkill);
            return createdStudentSkillResponse;
        }

        public async Task<CreatedStudentSkillResponse> AddStudentSkillByUserId(CreateStudentSkillByUserIdRequest createStudentSkillByUserIdRequest)
        {
            var student = _studentService.GetStudentByUserId(createStudentSkillByUserIdRequest.UserId);
            CreateStudentSkillRequest createStudentSkillRequest = new CreateStudentSkillRequest
            {
                StudentId = student.Id,
                SkillId = createStudentSkillByUserIdRequest.SkillId
            };
            StudentSkill studentSkill = _mapper.Map<StudentSkill>(createStudentSkillRequest);
            StudentSkill createdStudentSkill = await _studentSkillDal.AddAsync(studentSkill);
            CreatedStudentSkillResponse createdStudentSkillResponse = _mapper.Map<CreatedStudentSkillResponse>(createdStudentSkill);
            return createdStudentSkillResponse;
        }

        public async Task<DeletedStudentSkillResponse> Delete(DeleteStudentSkillRequest deleteStudentSkillRequest)
        {
            var data = await _studentSkillDal.GetAsync(i => i.Id == deleteStudentSkillRequest.Id);
            _mapper.Map(deleteStudentSkillRequest, data);
            var result = await _studentSkillDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedStudentSkillResponse>(result);
            return result2;
        }

        public async Task<CreatedStudentSkillResponse> GetById(int id)
        {
            var result = await _studentSkillDal.GetAsync(c => c.Id == id);
            StudentSkill mappedStudentSkill = _mapper.Map<StudentSkill>(result);
            CreatedStudentSkillResponse createdStudentSkillResponse = _mapper.Map<CreatedStudentSkillResponse>(mappedStudentSkill);
            return createdStudentSkillResponse;
        }

        public async Task<IPaginate<GetListStudentSkillResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _studentSkillDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListStudentSkillResponse>>(data);
            return result;
        }

        public async Task<UpdatedStudentSkillResponse> Update(UpdateStudentSkillRequest updateStudentSkillRequest)
        {
            var data = await _studentSkillDal.GetAsync(i => i.Id == updateStudentSkillRequest.Id);
            _mapper.Map(updateStudentSkillRequest, data);
            await _studentSkillDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedStudentSkillResponse>(data);
            return result;
        }

        public async Task<List<StudenSkillIdAndStudentSkillNameResponse>> GetStudentSkillsByUserIdAsync(Guid userId)
        {
            var student =  _studentService.GetStudentByUserId(userId);

            var studentSkills = await _studentSkillDal.GetListAsync(ss=>ss.StudentId==student.Id,
                                                                             include:query=>query
                                                                               .Include(ss=>ss.Skill));
            
            var result = _mapper.Map<List<StudenSkillIdAndStudentSkillNameResponse>>(studentSkills);

            return result;

        }
    }
}
