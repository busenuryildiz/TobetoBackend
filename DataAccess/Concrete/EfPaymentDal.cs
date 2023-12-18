using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Concrete
{
    public class EfPaymentDal : EfRepositoryBase<Payment, int, TobetoContext>, IPaymentDal
    {
        public EfPaymentDal(TobetoContext context) : base(context)
        {
        }
    }

}
