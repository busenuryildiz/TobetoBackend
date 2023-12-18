using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Concrete
{
    public class EfLessonDal : EfRepositoryBase<Lesson, int, TobetoContext>, ILessonDal
    {
        public EfLessonDal(TobetoContext context) : base(context)
        {
        }
    }

}
