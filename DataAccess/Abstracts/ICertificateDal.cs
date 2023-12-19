using Core.DataAccess.Repositories;
using Entities.Concretes.Profiles;

namespace DataAccess.Abstracts
{
    public interface ICertificateDal : IRepository<Certificate, int>, IAsyncRepository<Certificate, int>
    {
        // Certificate'a özgü metodlar buraya eklenebilir.
    }



}