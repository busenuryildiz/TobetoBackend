using Business.DTOs.Request.SocialMediaAccount;
using Business.DTOs.Response.Certificate;
using Business.DTOs.Response.SocialMediaAccount;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISocialMediaAccountService
    {
        Task<IPaginate<GetListSocialMediaAccountResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedSocialMediaAccountResponse> Add(CreateSocialMediaAccountRequest createSocialMediaAccountRequest);
        Task<UpdatedSocialMediaAccountResponse> Update(UpdateSocialMediaAccountRequest updateSocialMediaAccountRequest);
        Task<DeletedSocialMediaAccountResponse> Delete(DeleteSocialMediaAccountRequest deleteSocialMediaAccountRequest);
        Task<CreatedSocialMediaAccountResponse> GetById(int id);
        Task<IPaginate<GetListSocialMediaAccountResponse>> GetUsersAllSocialMediaAccount(Guid userId, int value = int.MaxValue);

    }
}
