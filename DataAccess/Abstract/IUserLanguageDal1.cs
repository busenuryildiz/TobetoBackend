using Core.DataAccess.Repositories;
using Entities.Concrete.Profile;

namespace DataAccess.Abstract
{
    public interface IUserLanguageDal : IRepository<UserLanguage, int>, IAsyncRepository<UserLanguage, int>
    {
        // UserLanguage'a özgü metodlar buraya eklenebilir.
        // Örneğin: GetUserLanguagesByUserId(Guid userId);
    }
