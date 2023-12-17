using Business.DTOs.Request.Exam;
using Business.DTOs.Response.Exam;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExamService
    {
        Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedExamResponse> Add(CreateExamRequest createExamRequest);
        Task<UpdatedExamResponse> Update(UpdateExamRequest updateExamRequest);
        Task<DeletedExamResponse> Delete(DeleteExamRequest deleteExamRequest);
        Task<CreatedExamResponse> GetById(Guid id);

    }
}
