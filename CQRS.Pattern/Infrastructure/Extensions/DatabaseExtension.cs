using CQRS.Pattern.Infrastructure.Configurations;
using CQRS.Pattern.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Pattern.Infrastructure.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDbCollection(
            this IServiceCollection services,
            ConnectionOptions connection
        )
        {
            services.AddDbContext<NpgsqlContext>(s => { s.UseNpgsql(connection.PostgresConnectionString); });
            services.AddSingleton<MongoDBContext>();
            return services;
        }
    }
}