using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfExamDal : EfRepositoryBase<Exam, Guid, TobetoContext>, IExamDal
    {

        public EfExamDal(TobetoContext context) : base(context)
        {

        }

    }
}
