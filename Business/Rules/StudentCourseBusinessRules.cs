using Core.Business.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class StudentCourseBusinessRules : BaseBusinessRules
    {
        private IStudentCourseDal _studentCourseDal;

        public StudentCourseBusinessRules(IStudentCourseDal studentCourseDal)
        {
            _studentCourseDal = studentCourseDal;
        }
        
    }
}
