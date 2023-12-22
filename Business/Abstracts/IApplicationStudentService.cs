using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.ApplicationStudent;
using Business.DTOs.Response.ApplicationStudent;

namespace Business.Abstracts
{
    public interface IApplicationStudentService
    {

        Task<IPaginate<GetListApplicationStudentResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedApplicationStudentResponse> Add(CreateApplicationStudentRequest createApplicationStudentRequest);
        Task<UpdatedApplicationStudentResponse> Update(UpdateApplicationStudentRequest updateApplicationStudentRequest);
        Task<DeletedApplicationStudentResponse> Delete(DeleteApplicationStudentRequest deleteApplicationStudentRequest);
        Task<CreatedApplicationStudentResponse> GetById(int id);
    }
}
