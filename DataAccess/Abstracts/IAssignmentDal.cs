using Core.DataAccess.Repositories;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Abstracts
{
    public interface IAssignmentDal : IRepository<Assignment, int>, IAsyncRepository<Assignment, int>
    {
    }





}
