using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface ILessonDal : IRepository<Lesson, int>, IAsyncRepository<Lesson, int>
    {
        // Lesson'a özgü metodlar buraya eklenebilir.
    }

    // Diğer IEntityDal'ları da aynı mantıkla oluşturabilirsiniz.




}