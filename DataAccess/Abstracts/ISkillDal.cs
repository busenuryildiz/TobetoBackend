using Core.DataAccess.Repositories;
using Entities.Concretes.Profiles;

namespace DataAccess.Abstracts
{
    public interface ISkillDal : IRepository<Skill, int>, IAsyncRepository<Skill, int>
    {
        // Skill'a özgü metodlar buraya eklenebilir.
    }



}