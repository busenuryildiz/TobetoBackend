using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Profiles;

namespace DataAccess.Concretes
{
    public class EfAddressDal : EfRepositoryBase<Address, int, TobetoContext>, IAddressDal
    {
        public EfAddressDal(TobetoContext context) : base(context)
        {
        }
    }
}
