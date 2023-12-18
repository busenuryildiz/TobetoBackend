using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfAnnouncementDal : EfRepositoryBase<Announcement, int, TobetoContext>, IAnnouncementDal
    {
        public EfAnnouncementDal(TobetoContext context) : base(context)
        {
        }
    }

}
