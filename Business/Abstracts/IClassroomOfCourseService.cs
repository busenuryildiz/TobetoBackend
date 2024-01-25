using Business.DTOs.Request.ClassroomOfCourse;
using Business.DTOs.Response.ClassroomOfCourse;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IClassroomOfCourseService
    {
        Task<IPaginate<GetListClassroomOfCourseResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedClassroomOfCourseResponse> Add(CreateClassroomOfCourseRequest createClassroomOfCourseRequest);
        Task<UpdatedClassroomOfCourseResponse> Update(UpdateClassroomOfCourseRequest updateClassroomOfCourseRequest);
        Task<DeletedClassroomOfCourseResponse> Delete(DeleteClassroomOfCourseRequest deleteClassroomOfCourseRequest);
        Task<CreatedClassroomOfCourseResponse> GetById(int id);
    }
}
