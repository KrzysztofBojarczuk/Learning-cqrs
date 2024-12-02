using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Queries
{
    public record GetUserEmployeesQuery(string appUserId) : IRequest<IEnumerable<EmployeeEntity>>;

    public class GetUserEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetUserEmployeesQuery, IEnumerable<EmployeeEntity>>
    {
        public async Task<IEnumerable<EmployeeEntity>> Handle(GetUserEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetUserEmployeesAsync(request.appUserId);
        }
    }
}

