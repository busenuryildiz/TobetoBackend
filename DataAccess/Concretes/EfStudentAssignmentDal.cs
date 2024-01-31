using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfStudentAssignmentDal : EfRepositoryBase<StudentAssignment, int, TobetoContext>, IStudentAssignmentDal
    {
        public EfStudentAssignmentDal(TobetoContext context) : base(context)
        {
        }
    }
}
