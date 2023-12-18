using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserRoleDal : IRepository<UserRole, int>, IAsyncRepository<UserRole, int>
    {
        // UserRole'a özgü metodlar buraya eklenebilir.
    }



}