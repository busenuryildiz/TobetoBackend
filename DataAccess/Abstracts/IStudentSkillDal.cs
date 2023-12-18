using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IStudentSkillDal : IRepository<StudentSkill, int>, IAsyncRepository<StudentSkill, int>
    {
        // StudentSkill'a özgü metodlar buraya eklenebilir.
    }



}