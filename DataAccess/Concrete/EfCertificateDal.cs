using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Profile;

namespace DataAccess.Concrete
{
    public class EfCertificateDal : EfRepositoryBase<Certificate, int, TobetoContext>, ICertificateDal
    {
        public EfCertificateDal(TobetoContext context) : base(context)
        {
        }
    }

}
