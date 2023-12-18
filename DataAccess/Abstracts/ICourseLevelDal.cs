using Core.DataAccess.Repositories;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ICourseLevelDal : IRepository<CourseLevel, int>, IAsyncRepository<CourseLevel, int>
    {
    }
}
