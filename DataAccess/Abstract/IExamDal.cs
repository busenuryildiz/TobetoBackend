using Core.DataAccess.Repositories;
using Entities.Concrete.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IExamDal : IRepository<Exam, int>, IAsyncRepository<Exam, int>
    {
    }
}
