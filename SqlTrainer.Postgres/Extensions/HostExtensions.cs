using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SqlTrainer.Postgres.Extensions;

public static class HostExtensions
{
    public static IHost MigrateDatabase<TContext>(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        
        var serviceProvider = scope.ServiceProvider;
        var dbUp = serviceProvider.GetRequiredService<IDbUpService>();
        var logger = serviceProvider.GetRequiredService<ILogger<TContext>>();

        logger.LogInformation("Migration start");
        var result = dbUp.Migrate();

        if (!result.Successful)
            logger.LogInformation("Migrated Postgres database.");
        else
            logger.LogInformation(result.Error, "An error occurred while migrating the Postgres database");

        return host;
    }
}
