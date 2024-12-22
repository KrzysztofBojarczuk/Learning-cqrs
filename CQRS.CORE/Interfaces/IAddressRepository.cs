using CQRS.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CORE.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<AddressEntity>> GetAllAddressesAsync();
        Task<IEnumerable<AddressEntity>> GetUserAddressesAsync(string appUserId);
        Task<AddressEntity> GetAddressByIdAsync(Guid id);
        Task<AddressEntity> AddAddressAsync(AddressEntity entity);
        Task<AddressEntity> UpdateAddressAsync(Guid addressId, AddressEntity entity);
        Task<bool> DeleteAddressAsync(Guid addressId);
    }
}