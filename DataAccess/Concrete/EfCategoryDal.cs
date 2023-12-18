using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : EfRepositoryBase<Category, int, TobetoContext>, ICategoryDal
    {
        public EfCategoryDal(TobetoContext context) : base(context)
        {
        }
    }

}
