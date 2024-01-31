using Core.DataAccess.Repositories;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Abstracts
{
    public interface ICourseSubjectDal : IRepository<CourseSubject, int>, IAsyncRepository<CourseSubject, int>
    {
    }
}