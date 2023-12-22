using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfCountyDal : EfRepositoryBase<County, int, TobetoContext>, ICountyDal
    {
        public EfCountyDal(TobetoContext context) : base(context)
        {
        }
    }
}
