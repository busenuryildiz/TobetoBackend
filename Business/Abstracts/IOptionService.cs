using Business.DTOs.Request.Option;
using Business.DTOs.Response.Option;
using Core.DataAccess.Paging;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IOptionService
    {

        Task<IPaginate<GetListOptionResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedOptionResponse> Add(CreateOptionRequest createOptionRequest);
        Task<UpdatedOptionResponse> Update(UpdateOptionRequest updateOptionRequest);
        Task<DeletedOptionResponse> Delete(DeleteOptionRequest deleteOptionRequest);
        Task<IPaginate<Option>> GetOptionsByQuestionId(int questionId);
        Task<Option> AddOptionToQuestion(int questionId, CreateOptionRequest createOptionRequest);



    }
}
