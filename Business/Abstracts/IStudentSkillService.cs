using Business.DTOs.Request.StudentSkill;
using Business.DTOs.Response.StudentSkill;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IStudentSkillService
    {
        Task<IPaginate<GetListStudentSkillResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedStudentSkillResponse> Add(CreateStudentSkillRequest createStudentSkillRequest);
        Task<UpdatedStudentSkillResponse> Update(UpdateStudentSkillRequest updateStudentSkillRequest);
        Task<DeletedStudentSkillResponse> Delete(DeleteStudentSkillRequest deleteStudentSkillRequest);
        Task<CreatedStudentSkillResponse> GetById(int id);
    }
}
