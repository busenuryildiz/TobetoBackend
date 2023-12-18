using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Profile;

namespace DataAccess.Concrete
{
    public class EfUserLanguageDal : EfRepositoryBase<UserLanguage, int, TobetoContext>, IUserLanguageDal
    {
        public EfUserLanguageDal(TobetoContext context) : base(context)
        {
        }
    }

}
