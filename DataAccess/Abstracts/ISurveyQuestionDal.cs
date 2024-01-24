using Core.DataAccess.Repositories;
using Entities.Concretes.Courses;
using Entities.Concretes.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ISurveyQuestionDal : IRepository<SurveyQuestion, int>, IAsyncRepository<SurveyQuestion, int>
    {
    }
}
