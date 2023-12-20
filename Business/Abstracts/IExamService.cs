using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.Exam;
using Business.DTOs.Response.Exam;

namespace Business.Abstracts
{
    public interface IExamService
    {
        Task<CreatedExamResponse> Add(CreateExamRequest createExamRequest);
        Task<DeletedExamResponse> Delete(DeleteExamRequest deleteExamRequest);
        Task<UpdatedExamResponse> Update(UpdateExamRequest updateExamRequest);
        Task<GetByIdExamResponse> GetById(int id);
        Task<IPaginate<GetListExamInfoResponse>> GetListAsync(PageRequest pageRequest);
    }
}
