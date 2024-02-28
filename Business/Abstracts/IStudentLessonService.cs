using Business.DTOs.Request.StudentLesson;
using Business.DTOs.Response.StudentLesson;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IStudentLessonService
    {
        Task<IPaginate<GetListStudentLessonResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedStudentLessonResponse> Add(CreateStudentLessonRequest createStudentLessonRequest);
        Task<UpdatedStudentLessonResponse> Update(UpdateStudentLessonRequest updateStudentLessonRequest);
        Task<DeletedStudentLessonResponse> Delete(DeleteStudentLessonRequest deleteStudentLessonRequest);
        Task<CreatedStudentLessonResponse> GetById(int id);

    }

}
