using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Courses;

namespace DataAccess.Concretes
{
    public class EfOptionDal : EfRepositoryBase<Option, int, TobetoContext>, IOptionDal
    {
        public EfOptionDal(TobetoContext context) : base(context)
        {
        }
    }

}
