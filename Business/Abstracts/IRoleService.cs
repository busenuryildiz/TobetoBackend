using Business.DTOs.Request.Role;
using Business.DTOs.Response.Role;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IRoleService
    {
        Task<IPaginate<GetListRoleResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedRoleResponse> Add(CreateRoleRequest createRoleRequest);
        Task<UpdatedRoleResponse> Update(UpdateRoleRequest updateRoleRequest);
        Task<DeletedRoleResponse> Delete(DeleteRoleRequest deleteRoleRequest);
        Task<CreatedRoleResponse> GetById(int id);
    }
}
