using CQRS.APPLICATION;
using CQRS.INFRASTRUCTURE;
using CQRS.CORE;

namespace CQRS.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddCoreDI(configuration);

            return services;
        }
    }
}
