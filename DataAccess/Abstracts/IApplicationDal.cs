using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IApplicationDal : IRepository<Application, int>, IAsyncRepository<Application, int>
    {
        // Application'a özgü metodlar buraya eklenebilir.
    }



}