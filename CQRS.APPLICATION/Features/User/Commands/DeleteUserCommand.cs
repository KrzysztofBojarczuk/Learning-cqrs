﻿using CQRS.CORE.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Features.User.Commands
{
    public record DeleteUserCommand(string appUserId) : IRequest<bool>;

    public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellation)
        {
            return await userRepository.DeleteUserAsync(request.appUserId);
        }
    }
}
