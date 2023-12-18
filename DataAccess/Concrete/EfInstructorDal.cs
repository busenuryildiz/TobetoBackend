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
    public class EfInstructorDal : EfRepositoryBase<Instructor, int, TobetoContext>, IInstructorDal
    {
        public EfInstructorDal(TobetoContext context) : base(context)
        {
        }
    }
}
