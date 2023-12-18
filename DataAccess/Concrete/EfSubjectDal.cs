using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfSubjectDal : EfRepositoryBase<Subject, int, TobetoContext>, ISubjectDal
    {
        public EfSubjectDal(TobetoContext context) : base(context)
        {
        }
    }

}
