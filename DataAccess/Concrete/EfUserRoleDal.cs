using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfUserRoleDal : EfRepositoryBase<UserRole, int, TobetoContext>, IUserRoleDal
    {
        public EfUserRoleDal(TobetoContext context) : base(context)
        {
        }
    }

}
