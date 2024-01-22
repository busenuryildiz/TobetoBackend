using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfSurveyQuestionDal : EfRepositoryBase<SurveyQuestion, int, TobetoContext>, ISurveyQuestionDal
    {
        public EfSurveyQuestionDal(TobetoContext context) : base(context)
        {
        }

        // ISurveyQuestionDal arayüzünden gelen özel metotları burada implemente edebilirsiniz.
    }
}
