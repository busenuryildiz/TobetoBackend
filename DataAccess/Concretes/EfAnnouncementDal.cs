using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfAnnouncementDal : EfRepositoryBase<Announcement, int, TobetoContext>, IAnnouncementDal
    {
        public EfAnnouncementDal(TobetoContext context) : base(context)
        {
        }
    }

}
