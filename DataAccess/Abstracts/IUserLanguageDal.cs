using Core.DataAccess.Repositories;
using Entities.Concretes.Profiles;

namespace DataAccess.Abstracts
{
    public interface IUserLanguageDal : IRepository<UserLanguage, int>, IAsyncRepository<UserLanguage, int>
    {
        // UserLanguage'a özgü metodlar buraya eklenebilir.
    }



}