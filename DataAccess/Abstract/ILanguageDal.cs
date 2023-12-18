using Core.DataAccess.Repositories;
using Entities.Concrete.Profile;

namespace DataAccess.Abstract
{
    public interface ILanguageDal : IRepository<Language, int>, IAsyncRepository<Language, int>
    {
        // Language'a özgü metodlar buraya eklenebilir.
    }



}