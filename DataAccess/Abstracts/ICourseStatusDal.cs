using Core.DataAccess.Repositories;
using Entities.Concretes.Courses;

namespace DataAccess.Abstracts
{
    public interface ICourseStatusDal : IRepository<CourseStatus, int>, IAsyncRepository<CourseStatus,int>
    {
    }
}