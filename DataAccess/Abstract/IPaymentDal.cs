using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface IPaymentDal : IRepository<Payment, int>, IAsyncRepository<Payment, int>
    {
        // Payment'a özgü metodlar buraya eklenebilir.
    }



}