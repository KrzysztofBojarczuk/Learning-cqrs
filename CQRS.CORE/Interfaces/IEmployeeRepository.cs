using CQRS.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CORE.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<int> GetNumberOfEmployeesAsync();
        Task<IEnumerable<EmployeeEntity>> GetUserEmployeesAsync(string appUserId);
        Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync();
        Task<EmployeeEntity> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity entity);
        Task<EmployeeEntity> UpdateEmployeeAsync(Guid employeeId, EmployeeEntity entity);
        Task<bool> DeleteEmployeeAsync(Guid employeeId);
    }
}
