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
    public class EfDistrictDal : EfRepositoryBase<District, int, TobetoContext>, IDistrictDal
    {
        public EfDistrictDal(TobetoContext context) : base(context)
        {
        }
    }
}
