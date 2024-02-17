using Business.DTOs.Request.BadgeOfUser;
using Business.DTOs.Response.BadgeOfUser;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBadgeOfUserService
    {
        Task<IPaginate<GetListBadgeOfUserResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedBadgeOfUserResponse> Add(CreateBadgeOfUserRequest createBadgeOfUserRequest);
        Task<UpdatedBadgeOfUserResponse> Update(UpdateBadgeOfUserRequest updateBadgeOfUserRequest);
        Task<DeletedBadgeOfUserResponse> Delete(DeleteBadgeOfUserRequest deleteBadgeOfUserRequest);
        Task<CreatedBadgeOfUserResponse> GetById(int id);
    }
}
