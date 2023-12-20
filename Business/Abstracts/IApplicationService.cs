using Business.DTOs.Request.Application;
using Business.DTOs.Response.Application;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicationService
    {
        Task<IPaginate<GetListApplicationResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedApplicationResponse> Add(CreateApplicationRequest createApplicationRequest);
        Task<UpdatedApplicationResponse> Update(UpdateApplicationRequest updateApplicationRequest);
        Task<DeletedApplicationResponse> Delete(DeleteApplicationRequest deleteApplicationRequest);
        Task<CreatedApplicationResponse> GetById(int id);
    }
}
