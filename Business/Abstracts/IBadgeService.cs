using Business.DTOs.Request.Badge;
using Business.DTOs.Response.Badge;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBadgeService
    {
        Task<IPaginate<GetListBadgeResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedBadgeResponse> Add(CreateBadgeRequest createBadgeRequest);
        Task<UpdatedBadgeResponse> Update(UpdateBadgeRequest updateBadgeRequest);
        Task<DeletedBadgeResponse> Delete(DeleteBadgeRequest deleteBadgeRequest);
        Task<CreatedBadgeResponse> GetById(int id);
    }
}
