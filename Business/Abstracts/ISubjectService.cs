using Business.DTOs.Request.Subject;
using Business.DTOs.Request.Subject;
using Business.DTOs.Response.Subject;
using Business.DTOs.Response.Subject;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISubjectService
    {
        Task<IPaginate<GetListSubjectResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedSubjectResponse> Add(CreateSubjectRequest createSubjectRequest);
        Task<UpdatedSubjectResponse> Update(UpdateSubjectRequest updateSubjectRequest);
        Task<DeletedSubjectResponse> Delete(DeleteSubjectRequest deleteSubjectRequest);
        Task<CreatedSubjectResponse> GetById(int id);
    }
}
