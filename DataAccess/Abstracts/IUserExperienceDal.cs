using Core.DataAccess.Repositories;
using Entities.Concretes.Profiles;

namespace DataAccess.Abstracts
{
    public interface IUserExperienceDal : IRepository<UserExperience, int>, IAsyncRepository<UserExperience, int>
    {
        // UserExperience'a özgü metodlar buraya eklenebilir.
    }



}