using Core.DataAccess.Repositories;
using Entities.Concrete.CourseFolder;

namespace DataAccess.Abstract
{
    public interface IQuestionDal : IRepository<Question, int>, IAsyncRepository<Question, int>
    {
        // Question'a özgü metodlar buraya eklenebilir.
    }



}