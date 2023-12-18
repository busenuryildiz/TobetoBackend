using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Profiles;

namespace DataAccess.Concretes
{
    public class EfLanguageDal : EfRepositoryBase<Language, int, TobetoContext>, ILanguageDal
    {
        public EfLanguageDal(TobetoContext context) : base(context)
        {
        }
    }

}
