using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Profile;

namespace DataAccess.Concrete
{
    public class EfLanguageLevelDal : EfRepositoryBase<LanguageLevel, int, TobetoContext>, ILanguageLevelDal
    {
        public EfLanguageLevelDal(TobetoContext context) : base(context)
        {
        }
    }

}
