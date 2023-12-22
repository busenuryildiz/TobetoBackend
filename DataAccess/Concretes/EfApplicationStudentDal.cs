using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfApplicationStudentDal:EfRepositoryBase<ApplicationStudent, int, TobetoContext>, IApplicationStudentDal
    {
        public EfApplicationStudentDal(TobetoContext context) : base(context)
        {
        }
    }
}
