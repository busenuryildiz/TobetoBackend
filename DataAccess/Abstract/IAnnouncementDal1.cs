using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAnnouncementDal : IRepository<Announcement, int>, IAsyncRepository<Announcement, int>
    {
        // Announcement'a özgü metodlar buraya eklenebilir.
        // Örneğin: GetActiveAnnouncements();
    }
