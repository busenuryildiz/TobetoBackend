using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.CoursesFolder;
using Business.DTOs.Request.Course;
using Business.DTOs.Response.Course;
using Business.DTOs.Response.Lesson;
using Business.DTOs.Response.StudentCourse;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest);
        Task<UpdatedCourseResponse> Update(UpdateCourseRequest updateCourseRequest);
        Task<DeletedCourseResponse> Delete(DeleteCourseRequest deleteCourseRequest);
        Task<CreatedCourseResponse> GetById(int id);
        Task<List<CreatedCourseResponse>> GetListAllCoursesAsync();

    }
}
