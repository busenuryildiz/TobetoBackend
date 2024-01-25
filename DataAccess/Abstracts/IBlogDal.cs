using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IBlogDal : IRepository<Blog, int>, IAsyncRepository<Blog, int>
    {
    }
}