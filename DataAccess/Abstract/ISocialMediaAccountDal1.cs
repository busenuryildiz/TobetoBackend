using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISocialMediaAccountDal : IRepository<SocialMediaAccount, int>, IAsyncRepository<SocialMediaAccount, int>
    {
        // SocialMediaAccount'a özgü metodlar buraya eklenebilir.
        // Örneğin: GetSocialMediaAccountsByUserId(int userId);
    }
