using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfStudentCourseDal : EfRepositoryBase<StudentCourse, int, TobetoContext>, IStudentCourseDal
    {
        public EfStudentCourseDal(TobetoContext context) : base(context)
        {
        }
    }

}
