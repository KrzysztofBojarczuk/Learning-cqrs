using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Commands
{
    public record AddEmployeeCommand(EmployeeEntity Employee) : IRequest<EmployeeEntity>;

    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, IPublisher mediator)
        : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var user = await employeeRepository.AddEmployeeAsync(request.Employee);
            return user;
        }
    }

}
