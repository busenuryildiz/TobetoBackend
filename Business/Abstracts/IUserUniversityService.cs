using Business.DTOs.Response.UserUniversity;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.UserUniversity;

namespace Business.Abstracts
{
    public interface IUserUniversityService
    {
        Task<IPaginate<GetListUserUniversityResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedUserUniversityResponse> Add(CreateUserUniversityRequest createUserUniversityRequest);
        Task<UpdatedUserUniversityResponse> Update(UpdateUserUniversityRequest updateUserUniversityRequest);
        Task<DeletedUserUniversityResponse> Delete(DeleteUserUniversityRequest deleteUserUniversityRequest);
        Task<CreatedUserUniversityResponse> GetById(int id);
    }
}
