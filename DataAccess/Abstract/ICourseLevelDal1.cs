using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface ICourseLevelDal : IRepository<CourseLevel, int>, IAsyncRepository<CourseLevel, int>
    {
        // CourseLevel'a özgü metodlar buraya eklenebilir.
    }

    // Diğer IEntityDal'ları da aynı mantıkla oluşturabilirsiniz.




}