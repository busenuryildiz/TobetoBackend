using Core.DataAccess.Repositories;
using Entities.Concrete.Profile;

namespace DataAccess.Abstract
{
    public interface IEducationInformationDal : IRepository<EducationInformation, int>, IAsyncRepository<EducationInformation, int>
    {
        // EducationInformation'a özgü metodlar buraya eklenebilir.
    }



}