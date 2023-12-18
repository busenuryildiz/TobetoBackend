using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfUserRoleDal : EfRepositoryBase<UserRole, int, TobetoContext>, IUserRoleDal
    {
        public EfUserRoleDal(TobetoContext context) : base(context)
        {
        }
    }

}
