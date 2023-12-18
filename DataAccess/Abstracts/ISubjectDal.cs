using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ISubjectDal : IRepository<Subject, int>, IAsyncRepository<Subject, int>
    {
        // Subject'e özgü metodlar buraya eklenebilir.
    }



}