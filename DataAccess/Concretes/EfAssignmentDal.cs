using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfAssignmentDal : EfRepositoryBase<Assignment, int, TobetoContext>, IAssignmentDal
    {
        public EfAssignmentDal(TobetoContext context) : base(context)
        {
        }
    }
}
