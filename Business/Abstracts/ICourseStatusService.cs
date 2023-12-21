using Business.DTOs.Request.CourseStatus;
using Business.DTOs.Response.CourseStatus;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICourseStatusService
    {
        Task<IPaginate<GetListCourseStatusResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCourseStatusResponse> Add(CreateCourseStatusRequest createCourseStatusRequest);
        Task<UpdatedCourseStatusResponse> Update(UpdateCourseStatusRequest updateCourseStatusRequest);
        Task<DeletedCourseStatusResponse> Delete(DeleteCourseStatusRequest deleteCourseStatusRequest);
        Task<CreatedCourseStatusResponse> GetById(int id);
    }
}
