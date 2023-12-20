using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfCourseSubjectDal : EfRepositoryBase<CourseSubject, int, TobetoContext>, ICourseSubjectDal
    {
        public EfCourseSubjectDal(TobetoContext context) : base(context)
        {
        }
    
    }
}
