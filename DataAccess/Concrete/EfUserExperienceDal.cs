using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Profile;

namespace DataAccess.Concrete
{
    public class EfUserExperienceDal : EfRepositoryBase<UserExperience, int, TobetoContext>, IUserExperienceDal
    {
        public EfUserExperienceDal(TobetoContext context) : base(context)
        {
        }
    }

}
