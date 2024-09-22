using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();

            return app;
        }
    }
}
