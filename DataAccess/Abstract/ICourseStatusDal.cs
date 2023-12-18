using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface ICourseStatusDal : IRepository<CourseStatus, int>, IAsyncRepository<CourseStatus,int>
    {
    }
}