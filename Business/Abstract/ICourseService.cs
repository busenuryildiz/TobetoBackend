using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.CourseFolder;

namespace Business.Abstract
{
    public interface ICourseService
    {
        Task<IPaginate<Course>> GetListAsync();
        
    }
}
