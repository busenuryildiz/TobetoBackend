using Core.DataAccess.Repositories;
using Entities.Concrete.Profile;

namespace DataAccess.Abstract
{
    public interface ILanguageLevelDal : IRepository<LanguageLevel, int>, IAsyncRepository<LanguageLevel, int>
    {
        // LanguageLevel'a özgü metodlar buraya eklenebilir.
    }



}