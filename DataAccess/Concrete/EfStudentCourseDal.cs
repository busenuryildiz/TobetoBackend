using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Concrete
{
    public class EfStudentCourseDal : EfRepositoryBase<StudentCourse, int, TobetoContext>, IStudentCourseDal
    {
        public EfStudentCourseDal(TobetoContext context) : base(context)
        {
        }
    }

}
