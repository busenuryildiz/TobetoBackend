using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface IAssignmentDal : IRepository<Assignment, int>, IAsyncRepository<Assignment, int>
    {
        // Assignment'a özgü metodlar buraya eklenebilir.
        // Örneğin: GetAssignmentsByCourseId(int courseId);
    }

    // Diğer IEntityDal'ları da aynı mantıkla oluşturabilirsiniz.

}