using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IUserRoleDal : IRepository<UserRole, int>, IAsyncRepository<UserRole, int>
    {
        public Task<List<string>> GetRolesByUserId(Guid userId);
    }

}