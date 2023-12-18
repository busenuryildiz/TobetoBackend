using Core.DataAccess.Repositories;
using Entities.Concretes.Courses;

namespace DataAccess.Abstracts
{
    public interface ILessonDal : IRepository<Lesson, int>, IAsyncRepository<Lesson, int>
    {
        // Lesson'a özgü metodlar buraya eklenebilir.
    }

    // Diğer IEntityDal'ları da aynı mantıkla oluşturabilirsiniz.




}