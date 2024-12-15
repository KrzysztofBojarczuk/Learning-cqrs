using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Features.Address.Command
{
    public record AddAddressCommand(AddressEntity Address) : IRequest<AddressEntity>;

    public class AddAddressCommandHandler(IAddressRepository addressRepository, IPublisher mediator) : IRequestHandler<AddAddressCommand, AddressEntity>
    {
        public async Task<AddressEntity> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var address =await addressRepository.AddAddressAsync(request.Address);
            return address;
        }
    }
}
