using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.Exam;
using Business.DTOs.Response.Exam;
using Business.DTOs.Response.Question;
using Entities.Concretes.CoursesFolder;

namespace Business.Abstracts
{
    public interface IExamService
    {
        Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedExamResponse> Add(CreateExamRequest createExamRequest);
        Task<UpdatedExamResponse> Update(UpdateExamRequest updateExamRequest);
        Task<DeletedExamResponse> Delete(DeleteExamRequest deleteExamRequest);
        Task<CreatedExamResponse> GetById(int id);
        Task<List<GetListExamResponse>> GetExamsByCourseId(int courseId);
        Task<List<GetListQuestionResponse>> GetRandomQuestionsByExamId(int examId);
        Task<StudentExamResultDto> SubmitExamResults(SubmitExamResultDto submitExamResultDto);
    }
}
