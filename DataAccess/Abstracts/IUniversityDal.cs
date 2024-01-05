using Core.DataAccess.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Profiles;

namespace DataAccess.Abstracts
{
    public interface IUniversityDal : IRepository<University, int>, IAsyncRepository<University, int>
    {
    }
}
