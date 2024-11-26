using CQRS.CORE.Interfaces;
using CQRS.INFRASTRUCTURE.Data;
using CQRS.INFRASTRUCTURE.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.INFRASTRUCTURE
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CQRS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
