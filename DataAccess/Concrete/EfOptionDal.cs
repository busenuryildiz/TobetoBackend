using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Concrete
{
    public class EfOptionDal : EfRepositoryBase<Option, int, TobetoContext>, IOptionDal
    {
        public EfOptionDal(TobetoContext context) : base(context)
        {
        }
    }

}
