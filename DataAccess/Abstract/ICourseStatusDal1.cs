using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface ICourseStatusDal : IRepository<CourseStatus, int>, IAsyncRepository<CourseStatus, int>
    {
        // CourseStatus'a özgü metodlar buraya eklenebilir.
    }

    // Diğer IEntityDal'ları da aynı mantıkla oluşturabilirsiniz.




}