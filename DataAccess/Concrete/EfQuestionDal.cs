using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Concrete
{
    public class EfQuestionDal : EfRepositoryBase<Question, int, TobetoContext>, IQuestionDal
    {
        public EfQuestionDal(TobetoContext context) : base(context)
        {
        }
    }

}
