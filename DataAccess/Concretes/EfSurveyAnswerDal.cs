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
    public class EfSurveyAnswerDal : EfRepositoryBase<SurveyAnswer, int, TobetoContext>, ISurveyAnswerDal
    {
        public EfSurveyAnswerDal(TobetoContext context) : base(context)
        {
        }

        // ISurverAnswerDal arayüzünden gelen özel metotları burada implemente edebilirsiniz.
    }
}
