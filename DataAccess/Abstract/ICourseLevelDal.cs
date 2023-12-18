using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICourseLevelDal : IRepository<CourseLevel, int>, IAsyncRepository<CourseLevel, int>
    {
    }
}
