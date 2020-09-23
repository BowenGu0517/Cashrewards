using Cashrewards.Application.Interfaces;
using Cashrewards.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Cashrewards.Infrastructure.Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddOptions()
                .Configure<DbSettings>(configuration.GetSection("DbSettings"))
                .AddTransient<IMerchantRepository, MerchantRepository>()
                .AddDataConnection();
        }

        private static IServiceCollection AddDataConnection(this IServiceCollection services)
        {
            services.AddTransient<IDbConnection>(serviceProvider =>
            {
                var dbSettings = serviceProvider.GetService<IOptions<DbSettings>>();
                var dbConnectionString = dbSettings.Value.DbConnectionString;

                return new SqlConnection(dbConnectionString);
            });

            return services;
        }
    }
}
