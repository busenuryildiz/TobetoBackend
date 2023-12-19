using Core.DataAccess.Repositories;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IInstructorDal : IRepository<Instructor, Guid>, IAsyncRepository<Instructor, Guid>
    {
    }
}
