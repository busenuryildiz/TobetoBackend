using Core.DataAccess.Repositories;
using Entities.Concretes.Courses;

namespace DataAccess.Abstracts
{
    public interface ISoftwareLanguageDal : IRepository<SoftwareLanguage, int>, IAsyncRepository<SoftwareLanguage, int>
    {
        // SoftwareLanguage'a özgü metodlar buraya eklenebilir.
    }



}