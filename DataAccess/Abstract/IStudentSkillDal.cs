using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IStudentSkillDal : IRepository<StudentSkill, int>, IAsyncRepository<StudentSkill, int>
    {
        // StudentSkill'a özgü metodlar buraya eklenebilir.
    }



}