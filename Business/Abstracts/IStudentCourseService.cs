using Business.DTOs.Request.StudentCourse;
using Business.DTOs.Response.Course;
using Business.DTOs.Response.StudentCourse;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IStudentCourseService
    {
        Task<CreatedStudentCourseResponse> Add(CreateStudentCourseRequest createStudentCourseRequest);
        Task<DeletedStudentCourseResponse> Delete(DeleteStudentCourseRequest deleteStudentCourseRequest);
        Task<UpdatedStudentCourseResponse> Update(UpdateStudentCourseRequest updateStudentCourseRequest);
        Task<CreatedStudentCourseResponse> GetById(int id);
        Task<IPaginate<GetListStudentCourseResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedStudentCourseResponse> GetCertificateByExamAndStudentCourseId(int examId, int studentCourseId);
        Task<IPaginate<GetListStudentCourseResponse>> GetListAsync(Guid studentId, PageRequest pageRequest);
        Task<List<GetUserBadgesResponse>> GetBadgesForCompletedCourses(Guid studentId);
        Task<List<GeneralStudentCourseList>> GetStudentsAllCoursesByUserId(Guid userId);
        Task<List<GeneralStudentCourseList>> GetStudentsOngoingCoursesByUserId(Guid userId);
        Task<List<GeneralStudentCourseList>> GetStudentsCompletedCoursesByUserId(Guid userId);
        Task<CoursesAllLessonInfoResponse> GetStudentsCourseAllInfo(int studentCourseId);
        public Task<int> GetIsLikedCountByCourseIdAsync(int courseId);
        Task<List<GeneralStudentCourseList>> GetListStudentsNotRegisteredCourses(Guid studentId);

    }
}
