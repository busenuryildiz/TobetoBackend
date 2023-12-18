using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category, int>, IAsyncRepository<Category, int>
    {
        // Category'e özgü metodlar buraya eklenebilir.
    }



}