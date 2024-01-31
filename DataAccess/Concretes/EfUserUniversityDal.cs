using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Profiles;

namespace DataAccess.Concretes
{
    public class EfUserUniversityDal : EfRepositoryBase<UserUniversity, int, TobetoContext>, IUserUniversityDal
    {
        public EfUserUniversityDal(TobetoContext context) : base(context)
        {
        }
    }
}
