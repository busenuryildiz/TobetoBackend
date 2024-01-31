using Core.DataAccess.Repositories;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IApplicationStudentDal : IRepository<ApplicationStudent, int>, IAsyncRepository<ApplicationStudent, int>
    {
    }
}
