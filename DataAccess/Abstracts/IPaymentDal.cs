using Core.DataAccess.Repositories;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Abstracts
{
    public interface IPaymentDal : IRepository<Payment, int>, IAsyncRepository<Payment, int>
    {
        // Payment'a özgü metodlar buraya eklenebilir.
    }



}