using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Courses;
using Entities.Concretes.Clients;

namespace DataAccess.Concretes
{
    public class EfExamDal : EfRepositoryBase<Exam, int, TobetoContext>, IExamDal
    {

        public EfExamDal(TobetoContext context) : base(context)
        {

        }

    }

}
