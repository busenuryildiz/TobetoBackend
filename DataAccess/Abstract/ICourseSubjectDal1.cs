using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface ICourseSubjectDal : IRepository<CourseSubject, int>, IAsyncRepository<CourseSubject, int>
    {
        // CourseSubject'a özgü metodlar buraya eklenebilir.
    }

    // Diğer IEntityDal'ları da aynı mantıkla oluşturabilirsiniz.




}