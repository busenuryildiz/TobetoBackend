using Core.DataAccess.Repositories;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Clients;

namespace DataAccess.Abstracts
{
    public interface IManagerDal : IRepository<Manager, Guid>, IAsyncRepository<Manager, Guid>
    {
    }
}
