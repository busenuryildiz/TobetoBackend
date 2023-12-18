using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ICategoryDal : IRepository<Category, int>, IAsyncRepository<Category, int>
    {
        // Category'e özgü metodlar buraya eklenebilir.
    }



}