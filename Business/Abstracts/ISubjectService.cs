using Business.DTOs.Request.Subject;
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
        Task<CreatedSubjectResponse> Add(CreateSubjectRequest createSubjectRequest);
        Task<DeletedSubjectResponse> Delete(DeleteSubjectRequest deleteSubjectRequest);
        Task<UpdatedSubjectResponse> Update(UpdateSubjectRequest updateSubjectRequest);
        Task<GetByIdSubjectResponse> GetById(int id);
        Task<IPaginate<GetListSubjectInfoResponse>> GetListAsync(PageRequest pageRequest);
    }
}
