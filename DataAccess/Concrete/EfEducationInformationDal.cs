using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Profile;

namespace DataAccess.Concrete
{
    public class EfEducationInformationDal : EfRepositoryBase<EducationInformation, int, TobetoContext>, IEducationInformationDal
    {
        public EfEducationInformationDal(TobetoContext context) : base(context)
        {
        }
    }

}
