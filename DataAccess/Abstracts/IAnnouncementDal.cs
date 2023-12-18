using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IAnnouncementDal : IRepository<Announcement, int>, IAsyncRepository<Announcement, int>
    {
        // Announcement'a özgü metodlar buraya eklenebilir.
    }

}