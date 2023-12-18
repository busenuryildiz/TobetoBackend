using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRoleDal : IRepository<Role, int>, IAsyncRepository<Role, int>
    {
        // Role'a özgü metodlar buraya eklenebilir.
    }



}