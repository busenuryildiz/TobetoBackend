using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IRepository<Blog, int>, IAsyncRepository<Blog, int>
    {
        // Blog'a özgü metodlar buraya eklenebilir.
        // Örneğin: GetLatestBlogs();
    }
