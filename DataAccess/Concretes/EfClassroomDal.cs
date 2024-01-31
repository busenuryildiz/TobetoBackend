using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfClassroomDal : EfRepositoryBase<Classroom, int, TobetoContext>, IClassroomDal
    {
        public EfClassroomDal(TobetoContext context) : base(context)
        {
        }
    }

}
