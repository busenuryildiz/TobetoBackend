using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfStudentDal : EfRepositoryBase<Student, Guid, TobetoContext>, IStudentDal
    {
        public EfStudentDal(TobetoContext context) : base(context)
        {
        }
    }
}
