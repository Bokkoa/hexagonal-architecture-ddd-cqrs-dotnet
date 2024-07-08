using Application.Abstractions.Ports.Repositories;
using Infrastructure.SqlServer.Databases;
using Infrastructure.SqlServer.Databases.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SqlServer
{
    public static class InfrastructureSqlServerLayerDependency
    {
        public static IServiceCollection AddSqlServerLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext, FinanceManagementContext>((provider, builder) =>
            {
                builder
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(
                        connectionString: configuration.GetConnectionString("FinanceManagementDB"),
                        sqlServerOptionsAction: options 
                            => options.MigrationsAssembly(typeof(FinanceManagementContext).Assembly.GetName().Name)
                    );
            });

            services.AddScoped<IFinanceManagementRepository, FinanceManagementRepository>();

            return services;
        }
    }
}
