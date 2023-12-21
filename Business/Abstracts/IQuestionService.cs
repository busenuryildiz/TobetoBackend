
using Business.DTOs.Request.Question;
using Business.DTOs.Response.Question;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IQuestionService
    {
        Task<IPaginate<GetListQuestionResponse>> GetListAsync(PageRequest pageRequest);
        //Task<CreatedQuestionResponse> Add(CreateQuestionRequest createQuestionRequest);
        Task<UpdatedQuestionResponse> Update(UpdateQuestionRequest updateQuestionRequest);
        Task<DeletedQuestionResponse> Delete(DeleteQuestionRequest deleteQuestionRequest);
        Task<CreatedQuestionResponse> GetById(int id);
        Task<List<GetListQuestionResponse>> GetQuestionsByExamId(int examId);
    }
}
