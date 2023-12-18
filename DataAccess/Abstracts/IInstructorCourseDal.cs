using Core.DataAccess.Repositories;
using Entities.Concretes.Courses;

namespace DataAccess.Abstracts
{
    public interface IInstructorCourseDal : IRepository<InstructorCourse, int>, IAsyncRepository<InstructorCourse, int>
    {
        // InstructorCourse'a özgü metodlar buraya eklenebilir.
        // Örneğin: GetInstructorCoursesByInstructorId(int instructorId);
    }



    // Diğer IEntityDal'ları da aynı mantıkla oluşturabilirsiniz.

}