using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Surveys;

namespace DataAccess.Concretes
{
    public class EfSurveyDal : EfRepositoryBase<Survey, int, TobetoContext>, ISurveyDal
    {
        public EfSurveyDal(TobetoContext context) : base(context)
        {
        }
    }

}
