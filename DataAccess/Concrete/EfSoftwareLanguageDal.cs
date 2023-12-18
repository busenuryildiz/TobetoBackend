using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Concrete
{
    public class EfSoftwareLanguageDal : EfRepositoryBase<SoftwareLanguage, int, TobetoContext>, ISoftwareLanguageDal
    {
        public EfSoftwareLanguageDal(TobetoContext context) : base(context)
        {
        }
    }

}
