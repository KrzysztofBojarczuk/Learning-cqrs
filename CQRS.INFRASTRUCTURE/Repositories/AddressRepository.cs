using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using CQRS.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.INFRASTRUCTURE.Repositories
{
    public class AddressRepository(AppDbContext dbContext) : IAddressRepository
    {
        public async Task<AddressEntity> AddAddressAsync(AddressEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Address.Add(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAddressAsync(Guid addressId)
        {
            var address = await dbContext.Address.FirstOrDefaultAsync(x => x.Id == addressId);

            if (address is not null)
            {
                dbContext.Address.Remove(address);

                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<AddressEntity> GetAddressByIdAsync(Guid id)
        {
            return await dbContext.Address.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AddressEntity>> GetUserAddressesAsync(string appUserId)
        {
            return await dbContext.Address.Where(x => x.AppUserId == appUserId).ToListAsync();
        }

        public async Task<AddressEntity> UpdateAddressAsync(Guid taskId, AddressEntity entity)
        {
            var address = await dbContext.Address.FirstOrDefaultAsync(x => x.Id == taskId);

            if (address is not null)
            {
                address.City = entity.City;
                address.Street = entity.Street;
                address.Number = entity.Number;
                address.ZipCode = entity.ZipCode;

                await dbContext.SaveChangesAsync();

                return address;
            }

            return entity;
        }
    }
}
