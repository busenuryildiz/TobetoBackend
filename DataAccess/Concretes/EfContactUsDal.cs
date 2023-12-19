using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfContactUsDal : EfRepositoryBase<ContactUs, int, TobetoContext>, IContactUsDal
    {
        public EfContactUsDal(TobetoContext context) : base(context)
        {
        }
    }

}
