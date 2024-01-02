using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.Concretes
{
    public class EfUserRoleDal : EfRepositoryBase<UserRole, int, TobetoContext>, IUserRoleDal
    {


        public EfUserRoleDal(TobetoContext context) : base(context)
        {

        }

        public async Task<List<string>> GetRolesByUserId(Guid userId)
        {
            var userRoles = await Context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .Select(ur => ur.Role.Name)
                .ToListAsync();

            return userRoles;
        }
    }

}
