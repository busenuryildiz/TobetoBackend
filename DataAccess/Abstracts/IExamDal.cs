using Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Abstracts
{
    public interface IExamDal : IRepository<Exam, int>, IAsyncRepository<Exam, int>
    {
    }
}
