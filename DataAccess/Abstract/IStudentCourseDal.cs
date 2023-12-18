using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface IStudentCourseDal : IRepository<StudentCourse, int>, IAsyncRepository<StudentCourse, int>
    {
        // StudentCourse'a özgü metodlar buraya eklenebilir.
    }



}