using Core.DataAccess.Repositories;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Abstracts
{
    // Diğer IEntityDal'ları da aynı mantıkla oluşturabilirsiniz.

    public interface IOptionDal : IRepository<Option, int>, IAsyncRepository<Option, int>
    {
        // Option'a özgü metodlar buraya eklenebilir.
    }



}