using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Features.User.Queries
{
    public record GetAllUserQuery() : IRequest<IEnumerable<AppUserEntity>>;
    
    public class GetAllUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllUserQuery, IEnumerable<AppUserEntity>>
    {
        public async Task<IEnumerable<AppUserEntity>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GettAllUsersAsync();
        }
    }
}
