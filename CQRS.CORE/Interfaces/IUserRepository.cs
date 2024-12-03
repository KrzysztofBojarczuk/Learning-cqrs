using CQRS.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CORE.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<AppUserEntity>> GettAllUsersAsync();
        Task<AppUserEntity> UpdateUserAsync(AppUserEntity updateUser);
        Task<AppUserEntity> DeleteUserAsync(string appUserId);
        Task<AppUserEntity> GetUserByIdAsync(string appUserId);
        Task<int> GetNumberUsersRepository();
    }
}
