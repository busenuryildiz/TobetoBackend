using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfBlogDal : EfRepositoryBase<Blog, int, TobetoContext>, IBlogDal
    {
        public EfBlogDal(TobetoContext context) : base(context)
        {
        }
    }

}
