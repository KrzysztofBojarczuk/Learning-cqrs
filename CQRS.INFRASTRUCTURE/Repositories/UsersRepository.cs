using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using CQRS.INFRASTRUCTURE.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.INFRASTRUCTURE.Repositories
{
    internal class UsersRepository(AppDbContext dbContext, UserManager<AppUserEntity> userManager) : IUserRepository
    {
        public async Task<bool> DeleteUserAsync(string appUserId)
        {
            var user = await userManager.FindByIdAsync(appUserId);

            if (user is not null)
            {
                await userManager.DeleteAsync(user);

                return true;
            }

            return false;
        }

        public Task<int> GetNumberUsersRepository()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AppUserEntity>> GettAllUsersAsync()
        {
            return await userManager.Users.ToListAsync();
        }

        public Task<AppUserEntity> GetUserByIdAsync(string appUserId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUserEntity> UpdateUserAsync(AppUserEntity updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
