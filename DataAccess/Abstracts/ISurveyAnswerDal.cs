using Core.DataAccess.Repositories;
using Entities.Concretes.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ISurveyAnswerDal : IRepository<SurveyAnswer, int>, IAsyncRepository<SurveyAnswer, int>
    {
        // SurverAnswer ile ilgili özel metotları buraya ekleyebilirsiniz.
    }
}
