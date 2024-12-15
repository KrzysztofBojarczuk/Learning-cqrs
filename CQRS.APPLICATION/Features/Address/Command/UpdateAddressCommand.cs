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
    public record UpdateAddressCommand(Guid AddressId, AddressEntity Address) : IRequest<AddressEntity>;

    public class UpdateAddressCommandHandler(IAddressRepository addressRepository) : IRequestHandler<UpdateAddressCommand, AddressEntity>
    {
        public async Task<AddressEntity> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            return await addressRepository.UpdateAddressAsync(request.AddressId, request.Address);
        }
    }
}
