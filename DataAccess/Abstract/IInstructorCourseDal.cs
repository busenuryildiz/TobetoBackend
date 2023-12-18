using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface IInstructorCourseDal : IRepository<InstructorCourse, int>, IAsyncRepository<InstructorCourse, int>
    {
        // InstructorCourse'a özgü metodlar buraya eklenebilir.
        // Örneğin: GetInstructorCoursesByInstructorId(int instructorId);
    }



    // Diğer IEntityDal'ları da aynı mantıkla oluşturabilirsiniz.

}