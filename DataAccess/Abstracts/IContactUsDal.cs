using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IContactUsDal : IRepository<ContactUs, int>, IAsyncRepository<ContactUs, int>
    {
        // ContactUs'a özgü metodlar buraya eklenebilir.
    }



}