using Business.Abstract;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        public Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest)
        {
            throw new NotImplementedException();
        }

        public Task<CreatedUserResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
        {
            throw new NotImplementedException();
        }

        public Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
