using Core.DataAccess.Repositories;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Abstracts
{
    public interface IClassroomOfCourseDal : IRepository<ClassroomOfCourse, int>, IAsyncRepository<ClassroomOfCourse, int>
    {
    }



}