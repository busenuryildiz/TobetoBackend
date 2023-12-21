using Business.DTOs.Request.UserExperience;
using Business.DTOs.Response.UserExperience;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserExperienceService
    {
        Task<IPaginate<GetListUserExperienceResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedUserExperienceResponse> Add(CreateUserExperienceRequest createUserExperienceRequest);
        Task<UpdatedUserExperienceResponse> Update(UpdateUserExperienceRequest updateUserExperienceRequest);
        Task<DeletedUserExperienceResponse> Delete(DeleteUserExperienceRequest deleteUserExperienceRequest);
        Task<GetListUserExperienceResponse> GetById(int id);
        Task<IPaginate<GetListUserExperienceResponse>> GetUserExperiencesByUserId(Guid userId);
    }
}
