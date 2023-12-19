using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IUserRoleDal : IRepository<UserRole, int>, IAsyncRepository<UserRole, int>
    {
        // UserRole'a özgü metodlar buraya eklenebilir.
    }



}