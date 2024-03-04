using Business.DTOs.Request.Lesson;
using Business.DTOs.Response.Lesson;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILessonService
    {
        Task<IPaginate<GetListLessonResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedLessonResponse> Add(CreateLessonRequest createLessonRequest);
        Task<UpdatedLessonResponse> Update(UpdateLessonRequest updateLessonRequest);
        Task<DeletedLessonResponse> Delete(DeleteLessonRequest deleteLessonRequest);
        Task<CreatedLessonResponse> GetById(int id);
        Task<List<GetListCourseAndLessonInfoResponse>> GetAllCourseAndLessonInfo();
        Task<List<GetListLessonResponse>> GetListCoursesAllLessonsAsync(int courseId);

    }
}
