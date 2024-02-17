using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Abstracts
{
    public interface ICoursePartDal: IRepository<CoursePart, int>, IAsyncRepository<CoursePart, int>
    {
    }
}
