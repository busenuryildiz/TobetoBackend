﻿using Core.DataAccess.Repositories;
using Entities.Concretes;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IStudentLessonDal : IRepository<StudentLesson, int>, IAsyncRepository<StudentLesson, int>
    {

    }

}
