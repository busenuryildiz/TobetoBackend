using Core.DataAccess.Repositories;
using Entities.Concretes.Profiles;

namespace DataAccess.Abstracts
{
    public interface ILanguageLevelDal : IRepository<LanguageLevel, int>, IAsyncRepository<LanguageLevel, int>
    {
        // LanguageLevel'a özgü metodlar buraya eklenebilir.
    }



}