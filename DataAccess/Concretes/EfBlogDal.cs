using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfBlogDal : EfRepositoryBase<Blog, int, TobetoContext>, IBlogDal
    {
        public EfBlogDal(TobetoContext context) : base(context)
        {
        }
    }

}
