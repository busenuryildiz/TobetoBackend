using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Courses;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task<IPaginate<Course>> GetListAsync();
        
    }
}
