using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.Profiles;

namespace DataAccess.Concretes
{
    public class EfSkillDal : EfRepositoryBase<Skill, int, TobetoContext>, ISkillDal
    {
        public EfSkillDal(TobetoContext context) : base(context)
        {
        }
    }

}
