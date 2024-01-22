using Core.DataAccess.Repositories;
using Entities.Concretes.Surveys;
using Entities.Concretes.Surveys;

namespace DataAccess.Abstracts
{
    public interface ISurveyDal : IRepository<Survey, int>, IAsyncRepository<Survey, int>
    {
        // Survey'a özgü metodlar buraya eklenebilir.
    }



}