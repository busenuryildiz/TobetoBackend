using Core.DataAccess.Repositories;
using Entities.Concretes;
using Entities.Concretes.Courses;

namespace DataAccess.Abstracts
{
    public interface IClassroomDal : IRepository<Classroom, int>, IAsyncRepository<Classroom, int>
    {

    }
}