using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISubjectDal : IRepository<Subject, int>, IAsyncRepository<Subject, int>
    {
        // Subject'e özgü metodlar buraya eklenebilir.
    }



}