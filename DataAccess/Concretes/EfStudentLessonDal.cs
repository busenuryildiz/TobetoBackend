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
    public class EfStudentLessonDal : EfRepositoryBase<StudentLesson, int, TobetoContext>, IStudentLessonDal
    {
        public EfStudentLessonDal(TobetoContext context) : base(context)
        {
        }
    }

}
