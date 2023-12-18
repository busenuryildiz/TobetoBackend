using Core.DataAccess.Repositories;
using Entities.Concrete.Profile;

namespace DataAccess.Abstract
{
    public interface ICertificateDal : IRepository<Certificate, int>, IAsyncRepository<Certificate, int>
    {
        // Certificate'a özgü metodlar buraya eklenebilir.
        // Örneğin: GetCertificatesByUserId(int userId);
    }
