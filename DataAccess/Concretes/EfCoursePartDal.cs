using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfCoursePartDal : EfRepositoryBase<CoursePart, int, TobetoContext>, ICoursePartDal
    {
        public EfCoursePartDal(TobetoContext context) : base(context)
        {
        }
    }
}