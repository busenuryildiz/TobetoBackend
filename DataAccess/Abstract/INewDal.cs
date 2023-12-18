using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface INewDal : IRepository<New, int>, IAsyncRepository<New, int>
    {
        // New'a özgü metodlar buraya eklenebilir.
    }



}