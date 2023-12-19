using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfSocialMediaAccountDal : EfRepositoryBase<SocialMediaAccount, int, TobetoContext>, ISocialMediaAccountDal
    {
        public EfSocialMediaAccountDal(TobetoContext context) : base(context)
        {
        }
    }

}
