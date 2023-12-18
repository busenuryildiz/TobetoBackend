using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Concrete
{
    public class EfInstructorCourseDal : EfRepositoryBase<InstructorCourse, int, TobetoContext>, IInstructorCourseDal
    {
        public EfInstructorCourseDal(TobetoContext context) : base(context)
        {
        }
    }

}
