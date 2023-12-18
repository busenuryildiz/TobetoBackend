using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfSurveyDal : EfRepositoryBase<Survey, int, TobetoContext>, ISurveyDal
    {
        public EfSurveyDal(TobetoContext context) : base(context)
        {
        }
    }

}
