using Business.DTOs.Request.CourseLevel;
using Business.DTOs.Response.CourseLevel;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICourseLevelService
    {
        Task<IPaginate<GetListCourseLevelResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCourseLevelResponse> Add(CreateCourseLevelRequest createCourseLevelRequest);
        Task<UpdatedCourseLevelResponse> Update(UpdateCourseLevelRequest updateCourseLevelRequest);
        Task<DeletedCourseLevelResponse> Delete(DeleteCourseLevelRequest deleteCourseLevelRequest);
        Task<CreatedCourseLevelResponse> GetById(int id);
    }
}
