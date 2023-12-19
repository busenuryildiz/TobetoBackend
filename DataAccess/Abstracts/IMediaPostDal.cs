using Core.DataAccess.Repositories;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IMediaPostDal : IRepository<MediaPost, int>, IAsyncRepository<MediaPost, int>
    {
    
    }
}
