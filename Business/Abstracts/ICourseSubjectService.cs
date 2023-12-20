using Business.DTOs.Request.CourseSubject;
using Business.DTOs.Response.CourseSubject;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICourseSubjectService
    {
        Task<IPaginate<GetListCourseSubjectResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCourseSubjectResponse> Add(CreateCourseSubjectRequest createCourseSubjectRequest);
        Task<UpdatedCourseSubjectResponse> Update(UpdateCourseSubjectRequest updateCourseSubjectRequest);
        Task<DeletedCourseSubjectResponse> Delete(DeleteCourseSubjectRequest deleteCourseSubjectRequest);
        Task<CreatedCourseSubjectResponse> GetById(int id);
    }
}
