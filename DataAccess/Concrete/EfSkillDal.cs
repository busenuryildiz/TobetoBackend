using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Profile;

namespace DataAccess.Concrete
{
    public class EfSkillDal : EfRepositoryBase<Skill, int, TobetoContext>, ISkillDal
    {
        public EfSkillDal(TobetoContext context) : base(context)
        {
        }
    }

}
