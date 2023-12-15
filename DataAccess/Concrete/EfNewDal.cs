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
    public class EfNewDal : EfRepositoryBase<New, Guid, TobetoContext>, INewDal
    {

        public EfNewDal(TobetoContext context) : base(context)
        {

        }

    }
}
