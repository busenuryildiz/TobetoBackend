using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.LessonCourse;
using Business.DTOs.Response.LessonCourse;

namespace Business.Abstracts
{
    public interface ILessonCourseService
    {
        Task<IPaginate<GetListLessonCourseResponse>> GetListAsync(int size);
        Task<CreatedLessonCourseResponse> Add(CreateLessonCourseRequest createLessonCourseRequest);
        Task<UpdatedLessonCourseResponse> Update(UpdateLessonCourseRequest updateLessonCourseRequest);
        Task<DeletedLessonCourseResponse> Delete(DeleteLessonCourseRequest deleteLessonCourseRequest);
        Task<CreatedLessonCourseResponse> GetById(int id);
    }
}
