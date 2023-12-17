using Core.DataAccess.Repositories;
using DataAccess.Context;
using Entities.Concrete.Client;
using Entities.Concrete.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IStudentDal: IRepository<Student, Guid>, IAsyncRepository<Student, Guid>
    {
    }
}
