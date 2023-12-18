using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Profiles;

namespace DataAccess.Concretes
{
    public class EfLanguageLevelDal : EfRepositoryBase<LanguageLevel, int, TobetoContext>, ILanguageLevelDal
    {
        public EfLanguageLevelDal(TobetoContext context) : base(context)
        {
        }
    }

}
