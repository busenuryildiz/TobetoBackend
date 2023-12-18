using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Clients;

namespace DataAccess.Concretes
{
    public class EfManagerDal : EfRepositoryBase<Manager, int, TobetoContext>, IManagerDal
    {
        public EfManagerDal(TobetoContext context) : base(context)
        {
        }
    }
}
