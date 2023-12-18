using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IApplicationDal : IRepository<Application, int>, IAsyncRepository<Application, int>
    {
        // Application'a özgü metodlar buraya eklenebilir.
        // Örneğin: GetActiveApplications();
    }
