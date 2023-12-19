using Business.DTOs.Request.Instructor;
using Business.DTOs.Request.Student;
using Business.DTOs.Response.Instructor;
using Business.DTOs.Response.Student;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest);
        Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest);
        Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest);
        Task<CreatedInstructorResponse> GetById(Guid id);
    }
}
