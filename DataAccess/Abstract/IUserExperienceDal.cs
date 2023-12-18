using Core.DataAccess.Repositories;
using Entities.Concrete.Profile;

namespace DataAccess.Abstract
{
    public interface IUserExperienceDal : IRepository<UserExperience, int>, IAsyncRepository<UserExperience, int>
    {
        // UserExperience'a özgü metodlar buraya eklenebilir.
    }



}