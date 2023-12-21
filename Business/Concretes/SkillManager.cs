using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Skill;
using Business.DTOs.Response.Skill;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;
        IMapper _mapper;
        SkillBusinessRules _businessRules;

        public SkillManager(SkillBusinessRules businessRules, ISkillDal skillDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _skillDal = skillDal;
            _mapper = mapper;
        }

        public async Task<CreatedSkillResponse> Add(CreateSkillRequest createSkillRequest)
        {
            Skill skill = _mapper.Map<Skill>(createSkillRequest);
            Skill createdSkill = await _skillDal.AddAsync(skill);
            CreatedSkillResponse createdSkillResponse = _mapper.Map<CreatedSkillResponse>(createdSkill);
            return createdSkillResponse;
        }

        public async Task<DeletedSkillResponse> Delete(DeleteSkillRequest deleteSkillRequest)
        {
            var data = await _skillDal.GetAsync(i => i.Id == deleteSkillRequest.Id);
            _mapper.Map(deleteSkillRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _skillDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedSkillResponse>(result);
            return result2;
        }

        public async Task<CreatedSkillResponse> GetById(int id)
        {
            var result = await _skillDal.GetAsync(c => c.Id == id);
            Skill mappedSkill = _mapper.Map<Skill>(result);

            CreatedSkillResponse createdSkillResponse = _mapper.Map<CreatedSkillResponse>(mappedSkill);

            return createdSkillResponse;
        }


        public async Task<IPaginate<GetListSkillResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _skillDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListSkillResponse>>(data);
            return result;
        }


        public async Task<UpdatedSkillResponse> Update(UpdateSkillRequest updateSkillRequest)
        {
            var data = await _skillDal.GetAsync(i => i.Id == updateSkillRequest.Id);
            _mapper.Map(updateSkillRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _skillDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedSkillResponse>(data);
            return result;
        }
    }
}
