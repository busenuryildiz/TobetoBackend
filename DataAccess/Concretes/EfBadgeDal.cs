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
    public class EfBadgeDal : EfRepositoryBase<Badge, int, TobetoContext>, IBadgeDal
    {
        public EfBadgeDal(TobetoContext context) : base(context)
        {
        }
    }
}
