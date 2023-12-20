using Business.DTOs.Request.Announcement;
using Business.DTOs.Request.Assignments;
using Business.DTOs.Response.Announcement;
using Business.DTOs.Response.Assignments;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAssignmentService
    {
        Task<IPaginate<GetListAssignmentResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedAssignmentResponse> Add(CreateAssignmentRequest createAssignmentRequest);
        Task<UpdatedAssignmentResponse> Update(UpdateAssignmentRequest updateAssignmentRequest);
        Task<DeletedAssignmentResponse> Delete(DeleteAssignmentRequest deleteAssignmentRequest);
        Task<CreatedAssignmentResponse> GetById(int id);
    }
}
