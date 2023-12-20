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
        Task<CreatedCourseLevelResponse> Add(CreateCourseLevelRequest createCourseLevelRequest);
        Task<DeletedCourseLevelResponse> Delete(DeleteCourseLevelRequest deleteCourseLevelRequest);
        Task<bool> Update(UpdateCourseLevelRequest updateCourseLevelRequest);
        Task<CreatedCourseLevelResponse> GetById(int id);
        Task<IPaginate<GetListCourseLevelResponse>> GetListAsync(PageRequest pageRequest);
    }
}
