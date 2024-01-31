using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfClassroomOfCourseDal : EfRepositoryBase<ClassroomOfCourse, int, TobetoContext>, IClassroomOfCourseDal
    {
        public EfClassroomOfCourseDal(TobetoContext context) : base(context)
        {
        }
    }

}
