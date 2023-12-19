using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfMediaPostDal : EfRepositoryBase<MediaPost, int, TobetoContext>, IMediaPostDal
    {
        public EfMediaPostDal(TobetoContext context) : base(context)
        {
        }
    }
}
