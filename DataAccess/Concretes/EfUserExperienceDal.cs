using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Profiles;

namespace DataAccess.Concretes
{
    public class EfUserExperienceDal : EfRepositoryBase<UserExperience, int, TobetoContext>, IUserExperienceDal
    {
        public EfUserExperienceDal(TobetoContext context) : base(context)
        {
        }
    }

}
