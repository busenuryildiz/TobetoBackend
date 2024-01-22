using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.StudentSkill;
using Business.DTOs.Response.StudentSkill;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class StudentSkillManager:IStudentSkillService
    {
        IStudentSkillDal _studentSkillDal;
        IMapper _mapper;
        StudentSkillBusinessRules _businessRules;

        public StudentSkillManager(StudentSkillBusinessRules businessRules, IStudentSkillDal studentSkillDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _studentSkillDal = studentSkillDal;
            _mapper = mapper;
        }

        public async Task<CreatedStudentSkillResponse> Add(CreateStudentSkillRequest createStudentSkillRequest)
        {
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
    }
}
