using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.UserRole;
using Business.DTOs.Response.UserRole;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IUserRoleService
    {
        Task<IPaginate<GetListUserRoleResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedUserRoleResponse> Add(CreateUserRoleRequest createUserRoleRequest);
        Task<UpdatedUserRoleResponse> Update(UpdateUserRoleRequest updateUserRoleRequest);
        Task<DeletedUserRoleResponse> Delete(DeleteUserRoleRequest deleteUserRoleRequest);
        Task<CreatedUserRoleResponse> GetById(int id);
    }
}
