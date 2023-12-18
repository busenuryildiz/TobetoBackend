using Core.DataAccess.Repositories;
using DataAccess.Context;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IStudentDal: IRepository<Student, Guid>, IAsyncRepository<Student, Guid>
    {
    }
}
