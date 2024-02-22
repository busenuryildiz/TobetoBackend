using Business.DTOs.Request.StudentAssignment;
using Business.DTOs.Response.StudentAssignment;
using Business.DTOs.Response.StudentCourse;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IStudentAssignmentService
    {
        Task<IPaginate<GetListStudentAssignmentResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedStudentAssignmentResponse> Add(CreateStudentAssignmentRequest createStudentAssignmentRequest);
        Task<UpdatedStudentAssignmentResponse> Update(UpdateStudentAssignmentRequest updateStudentAssignmentRequest);
        Task<DeletedStudentAssignmentResponse> Delete(DeleteStudentAssignmentRequest deleteStudentAssignmentRequest);
        Task<CreatedStudentAssignmentResponse> GetById(int id);
        Task<List<GetListStudentsAssigmentsAndDates>> GetStudentAssignmentAndDateByUserId(Guid userId);
    }
}
