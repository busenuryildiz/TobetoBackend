using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Profiles;

namespace DataAccess.Concretes
{
    public class EfUserLanguageDal : EfRepositoryBase<UserLanguage, int, TobetoContext>, IUserLanguageDal
    {
        public EfUserLanguageDal(TobetoContext context) : base(context)
        {
        }
    }

}
