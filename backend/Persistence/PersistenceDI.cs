using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceDI
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            var postgresDb = Environment.GetEnvironmentVariable("POSTGRES_DB");
            var postgresUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
            var postgresPass = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            var postgresPort = Environment.GetEnvironmentVariable("POSTGRES_PORT");
            var connectionString = $"Host=localhost;Database={postgresDb};Username={postgresUser};Password={postgresPass}";
            Console.WriteLine(connectionString);
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
