using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfRoleDal : EfRepositoryBase<Role, int, TobetoContext>, IRoleDal
    {
        public EfRoleDal(TobetoContext context) : base(context)
        {
        }
    }

}
