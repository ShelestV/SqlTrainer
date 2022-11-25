using SqlTrainer.Persistence.DbUp;

namespace WebApi.Extensions;

public static class MigrationExtensions
{
    public static WebApplication Migrate<TContext>(this WebApplication host)
    {
        using var services = host.Services.CreateScope();
        var dbUpService = services.ServiceProvider.GetRequiredService<IDbUpService>();
        var logger = services.ServiceProvider.GetRequiredService<ILogger<TContext>>();

        var result = dbUpService.MigrateDb();

        if (!result.Successful)
        {
            logger.LogInformation("{ResultError}", result.Error);
            return host;
        }

        logger.LogInformation("Database migrated successfully");

        return host;
    }
}
