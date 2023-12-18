using Core.DataAccess.Repositories;
using Entities.Concrete.Profile;

namespace DataAccess.Abstract
{
    public interface ISkillDal : IRepository<Skill, int>, IAsyncRepository<Skill, int>
    {
        // Skill'a özgü metodlar buraya eklenebilir.
    }



}