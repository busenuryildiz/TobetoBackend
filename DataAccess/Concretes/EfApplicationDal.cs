using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfApplicationDal : EfRepositoryBase<Application, int, TobetoContext>, IApplicationDal
    {
        public EfApplicationDal(TobetoContext context) : base(context)
        {
        }
    }

}
