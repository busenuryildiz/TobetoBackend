using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Profile;

namespace DataAccess.Concrete
{
    public class EfLanguageDal : EfRepositoryBase<Language, int, TobetoContext>, ILanguageDal
    {
        public EfLanguageDal(TobetoContext context) : base(context)
        {
        }
    }

}
