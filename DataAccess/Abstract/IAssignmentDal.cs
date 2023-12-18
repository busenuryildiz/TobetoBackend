using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface IAssignmentDal : IRepository<Assignment, int>, IAsyncRepository<Assignment, int>
    {
    }





}
