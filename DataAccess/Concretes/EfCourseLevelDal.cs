using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{

    public class EfCourseLevelDal : EfRepositoryBase<CourseLevel, int, TobetoContext>, ICourseLevelDal
    {
        public EfCourseLevelDal(TobetoContext context) : base(context)
        {
        }
    }
}
