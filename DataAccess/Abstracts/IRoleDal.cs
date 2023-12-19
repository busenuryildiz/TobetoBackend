using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IRoleDal : IRepository<Role, int>, IAsyncRepository<Role, int>
    {
        // Role'a özgü metodlar buraya eklenebilir.
    }



}