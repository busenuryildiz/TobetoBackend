using Business.DTOs.Request.InstructorCourse;
using Business.DTOs.Response.InstructorCourse;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorCourseService
    {
        Task<IPaginate<GetListInstructorCourseResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedInstructorCourseResponse> Add(CreateInstructorCourseRequest createInstructorCourseRequest);
        Task<UpdatedInstructorCourseResponse> Update(UpdateInstructorCourseRequest updateInstructorCourseRequest);
        Task<DeletedInstructorCourseResponse> Delete(DeleteInstructorCourseRequest deleteInstructorCourseRequest);
        Task<CreatedInstructorCourseResponse> GetById(int id);
    }
}
