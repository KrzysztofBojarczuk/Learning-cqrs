using CQRS.CORE.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Features.Address.Command
{
    public record DeleteAddressCommand(Guid AddressId) : IRequest<bool>;

    public class DeleteAddressCommandHandler(IAddressRepository addressRepository) : IRequestHandler<DeleteAddressCommand, bool>
    {
        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            return await addressRepository.DeleteAddressAsync(request.AddressId);
        }
    }
}
