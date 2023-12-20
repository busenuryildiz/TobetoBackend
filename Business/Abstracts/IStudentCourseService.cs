using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Response.StudentCourse;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IStudentCourseService
    {
        Task<CreatedStudentCourseResponse> Add(CreateStudentCourseRequest createStudentCourseRequest);
        Task<DeletedStudentCourseResponse> Delete(DeleteStudentCourseRequest deleteStudentCourseRequest);
        Task<UpdatedStudentCourseResponse> Update(UpdateStudentCourseRequest updateStudentCourseRequest);
        Task<CreatedStudentCourseResponse> GetById(int id);
        Task<IPaginate<GetListStudentCourseInfoResponse>> GetListAsync(PageRequest pageRequest);
    }
}
