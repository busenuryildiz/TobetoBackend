using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfNewDal : EfRepositoryBase<New, int, TobetoContext>, INewDal
    {
        public EfNewDal(TobetoContext context) : base(context)
        {
        }
    }

}
