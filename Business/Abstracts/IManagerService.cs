using Business.DTOs.Request.Manager;
using Business.DTOs.Response.Manager;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IManagerService
    {
        Task<IPaginate<GetListManagerResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedManagerResponse> Add(CreateManagerRequest createManagerRequest);
        Task<UpdatedManagerResponse> Update(UpdateManagerRequest updateManagerRequest);
        Task<DeletedManagerResponse> Delete(DeleteManagerRequest deleteManagerRequest);
        Task<CreatedManagerResponse> GetById(Guid id);
    }
}
