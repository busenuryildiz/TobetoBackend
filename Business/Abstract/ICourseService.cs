using Core.DataAccess.Paging;
using Entities.Concrete.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseService
    {
        Task<IPaginate<Course>> GetListAsync();
        
    }
}
