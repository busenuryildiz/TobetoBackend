using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfSocialMediaAccountDal : EfRepositoryBase<SocialMediaAccount, int, TobetoContext>, ISocialMediaAccountDal
    {
        public EfSocialMediaAccountDal(TobetoContext context) : base(context)
        {
        }
    }

}
