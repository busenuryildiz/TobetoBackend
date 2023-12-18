using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfStudentSkillDal : EfRepositoryBase<StudentSkill, int, TobetoContext>, IStudentSkillDal
    {
        public EfStudentSkillDal(TobetoContext context) : base(context)
        {
        }
    }

}
