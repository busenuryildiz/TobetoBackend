using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface ISoftwareLanguageDal : IRepository<SoftwareLanguage, int>, IAsyncRepository<SoftwareLanguage, int>
    {
        // SoftwareLanguage'a özgü metodlar buraya eklenebilir.
    }



}