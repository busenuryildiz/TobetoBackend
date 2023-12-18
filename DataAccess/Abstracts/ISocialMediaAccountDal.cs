using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ISocialMediaAccountDal : IRepository<SocialMediaAccount, int>, IAsyncRepository<SocialMediaAccount, int>
    {
        // SocialMediaAccount'a özgü metodlar buraya eklenebilir.
    }



}