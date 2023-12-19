using Core.DataAccess.Repositories;
using Entities.Concretes.Profiles;

namespace DataAccess.Abstracts
{
    public interface ILanguageDal : IRepository<Language, int>, IAsyncRepository<Language, int>
    {
        // Language'a özgü metodlar buraya eklenebilir.
    }



}