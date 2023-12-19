using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfRoleDal : EfRepositoryBase<Role, int, TobetoContext>, IRoleDal
    {
        public EfRoleDal(TobetoContext context) : base(context)
        {
        }
    }

}
