using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfApplicationDal : EfRepositoryBase<Application, int, TobetoContext>, IApplicationDal
    {
        public EfApplicationDal(TobetoContext context) : base(context)
        {
        }
    }

}
