using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Clients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfStudentDal : EfRepositoryBase<Student, Guid, TobetoContext>, IStudentDal
    {
        public EfStudentDal(TobetoContext context) : base(context)
        {

        }
        


    }
}
