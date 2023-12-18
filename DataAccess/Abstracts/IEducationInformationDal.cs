using Core.DataAccess.Repositories;
using Entities.Concretes.Profiles;

namespace DataAccess.Abstracts
{
    public interface IEducationInformationDal : IRepository<EducationInformation, int>, IAsyncRepository<EducationInformation, int>
    {
        // EducationInformation'a özgü metodlar buraya eklenebilir.
    }



}