using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IContactUsDal : IRepository<ContactUs, int>, IAsyncRepository<ContactUs, int>
    {
        // ContactUs'a özgü metodlar buraya eklene

    }
    }