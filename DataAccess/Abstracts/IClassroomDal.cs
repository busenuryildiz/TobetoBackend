using Core.DataAccess.Repositories;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Abstracts
{
    public interface IClassroomDal : IRepository<Classroom, int>, IAsyncRepository<Classroom, int>
    {

    }
}