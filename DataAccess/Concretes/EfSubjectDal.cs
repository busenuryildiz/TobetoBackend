using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfSubjectDal : EfRepositoryBase<Subject, int, TobetoContext>, ISubjectDal
    {
        public EfSubjectDal(TobetoContext context) : base(context)
        {
        }
    }

}
