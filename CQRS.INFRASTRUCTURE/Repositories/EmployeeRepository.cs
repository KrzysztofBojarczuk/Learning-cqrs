﻿using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using CQRS.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.INFRASTRUCTURE.Repositories
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetUserEmployeesAsync(string appUserId)
        {
            return await dbContext.Employees
                .Where(e => e.AppUserId == appUserId)
                .ToListAsync();
        }

        public async Task<int> GetNumberOfEmployeesAsync()
        {
            return await dbContext.Employees.CountAsync();
        }
        public async Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity entity)
        {
            entity.Id = Guid.NewGuid(); //służy do przypisania nowego, unikalnego identyfikatora
            dbContext.Employees.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<EmployeeEntity> UpdateEmployeeAsync(Guid employeeId, EmployeeEntity entity)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee is not null)
            {
                employee.Name = entity.Name;
                employee.Email = entity.Email;
                employee.Phone = entity.Phone;

                await dbContext.SaveChangesAsync();

                return employee;
            }

            return entity;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid employeeId)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);

                return await dbContext.SaveChangesAsync() > 0; //Jeśli usunięcie się powiodło: SaveChangesAsync() zwróci liczbę większą od 0, więc metoda zwróci true.
            }

            return false;
        }
    }
}
