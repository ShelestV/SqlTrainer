using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SqlTrainer.Persistence.Configurations;

namespace SqlTrainer.Postgres.Extensions;

public static class HostExtension
{
    public static IHost MigrateDatabase<TContext>(this IHost host, Type type)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var dbUp = services.GetRequiredService<IDbUpService>();
            var logger = services.GetRequiredService<ILogger<TContext>>();

            logger.LogInformation("Migration start");
            var result = dbUp.Migrate(type.Assembly);

            if (!result.Successful)
            {
                logger.LogInformation(result.Error, "An error occurred while migrating the postresql database");
                return host;
            }

            logger.LogInformation("Migrated postresql database.");
        }
        return host;
    }
}
