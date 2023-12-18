using Core.DataAccess.Repositories;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Clients;

namespace DataAccess.Abstracts
{
    public interface IManagerDal : IRepository<Manager, int>, IAsyncRepository<Manager, int>
    {
    }
}
