using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfExamDal : EfRepositoryBase<Exam, int, TobetoContext>, IExamDal
    {

        public EfExamDal(TobetoContext context) : base(context)
        {

        }

    }
}
