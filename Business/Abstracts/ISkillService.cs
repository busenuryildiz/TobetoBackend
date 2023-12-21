using Business.DTOs.Request.Skill;
using Business.DTOs.Response.Skill;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISkillService
    {
        Task<IPaginate<GetListSkillResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedSkillResponse> Add(CreateSkillRequest createSkillRequest);
        Task<UpdatedSkillResponse> Update(UpdateSkillRequest updateSkillRequest);
        Task<DeletedSkillResponse> Delete(DeleteSkillRequest deleteSkillRequest);
        Task<CreatedSkillResponse> GetById(int id);
    }
}
