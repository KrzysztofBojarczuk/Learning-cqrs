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
    public record GetAllAddressesQuery() : IRequest<IEnumerable<AddressEntity>>;
    
    public class GetAllAddressesQueryHandler(IAddressRepository addressRepository) :
        IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressEntity>>
    {
        public async Task<IEnumerable<AddressEntity>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            return await addressRepository.GetAllAddressesAsync();
        }
    }
}
