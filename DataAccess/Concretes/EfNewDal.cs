using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfNewDal : EfRepositoryBase<New, int, TobetoContext>, INewDal
    {
        public EfNewDal(TobetoContext context) : base(context)
        {
        }
    }

}
