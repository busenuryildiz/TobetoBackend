using Business.DTOs.Request.User;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest);
        Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest);
        Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest);
        Task<CreatedUserResponse> GetById(Guid id);

    }
}
