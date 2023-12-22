using Core.DataAccess.Repositories;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ICityDal : IRepository<City, int>, IAsyncRepository<City, int>
    {
        // City'e özgü metodlar buraya eklenebilir.

    }
}
