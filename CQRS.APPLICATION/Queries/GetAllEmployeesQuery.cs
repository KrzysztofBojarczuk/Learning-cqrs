﻿using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Queries
{
    public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeEntity>>;
    public class GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeEntity>>
    {
        public async Task<IEnumerable<EmployeeEntity>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployees();
        }
    }
}
