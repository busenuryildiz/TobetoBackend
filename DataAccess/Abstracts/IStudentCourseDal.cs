using Core.DataAccess.Repositories;
using Entities.Concretes.Courses;

namespace DataAccess.Abstracts
{
    public interface IStudentCourseDal : IRepository<StudentCourse, int>, IAsyncRepository<StudentCourse, int>
    {
        // StudentCourse'a özgü metodlar buraya eklenebilir.
    }



}