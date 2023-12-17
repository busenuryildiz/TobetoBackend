using Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface ICourseDal : IRepository<Course, int>, IAsyncRepository<Course, int>
    {
    }
}
