using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Features.Address.Queries
{
    public record GetUsserAddressesQuery(string appUserId) : IRequest<IEnumerable<AddressEntity>>;

    public class GetUserAddresesQueryHandler(IAddressRepository addressRepository) : IRequestHandler<GetUsserAddressesQuery, IEnumerable<AddressEntity>>
    {
        public async Task<IEnumerable<AddressEntity>> Handle(GetUsserAddressesQuery request, CancellationToken cancellationToken)
        {
            return await addressRepository.GetUserAddressesAsync(request.appUserId);
        }
    }
}
