using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfStudentSkillDal : EfRepositoryBase<StudentSkill, int, TobetoContext>, IStudentSkillDal
    {
        public EfStudentSkillDal(TobetoContext context) : base(context)
        {
        }
    }

}
