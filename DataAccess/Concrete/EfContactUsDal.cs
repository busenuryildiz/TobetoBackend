using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfContactUsDal : EfRepositoryBase<ContactUs, int, TobetoContext>, IContactUsDal
    {
        public EfContactUsDal(TobetoContext context) : base(context)
        {
        }
    }

}
