using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Profiles;

namespace DataAccess.Concretes
{
    public class EfEducationInformationDal : EfRepositoryBase<EducationInformation, int, TobetoContext>, IEducationInformationDal
    {
        public EfEducationInformationDal(TobetoContext context) : base(context)
        {
        }
    }

}
