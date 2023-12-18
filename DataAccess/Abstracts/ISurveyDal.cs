using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ISurveyDal : IRepository<Survey, int>, IAsyncRepository<Survey, int>
    {
        // Survey'a özgü metodlar buraya eklenebilir.
    }



}