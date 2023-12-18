using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfCategoryDal : EfRepositoryBase<Category, int, TobetoContext>, ICategoryDal
    {
        public EfCategoryDal(TobetoContext context) : base(context)
        {
        }
    }

}
