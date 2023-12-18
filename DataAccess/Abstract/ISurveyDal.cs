using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISurveyDal : IRepository<Survey, int>, IAsyncRepository<Survey, int>
    {
        // Survey'a özgü metodlar buraya eklenebilir.
    }



}