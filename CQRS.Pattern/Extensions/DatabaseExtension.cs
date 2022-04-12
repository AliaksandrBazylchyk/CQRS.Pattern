using CQRS.Pattern.Configurations;
using CQRS.Pattern.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Pattern.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDbCollection(
            this IServiceCollection services,
            ConnectionOptions connection
        )
        {
            services.AddDbContext<NpgsqlContext>(s => { s.UseNpgsql(connection.PostgresConnectionString); });

            return services;
        }
    }
}