using Business.Abstract;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public async Task<IPaginate<Course>> GetListAsync()
        {
            var result = await _courseDal.GetListAsync();
            return result;
        }
    }
}
