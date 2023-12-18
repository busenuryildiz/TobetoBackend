using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface INewDal : IRepository<New, int>, IAsyncRepository<New, int>
    {
        // New'a özgü metodlar buraya eklenebilir.
    }



}