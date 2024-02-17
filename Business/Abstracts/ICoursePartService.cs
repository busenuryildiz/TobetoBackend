using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.CoursePart;
using Business.DTOs.Response.CoursePart;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICoursePartService
    {
        Task<IPaginate<GetListCoursePartResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCoursePartResponse> Add(CreateCoursePartRequest createCoursePartRequest);
        Task<UpdatedCoursePartResponse> Update(UpdateCoursePartRequest updateCoursePartRequest);
        Task<DeletedCoursePartResponse> Delete(DeleteCoursePartRequest deleteCoursePartRequest);
        Task<GetCoursePartByIdResponse> GetById(int id);
    }
}
