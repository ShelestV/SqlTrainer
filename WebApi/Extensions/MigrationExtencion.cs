using SqlTrainer.Persistance.DbUp;

namespace WebApi.Extensions;

public static class MigrationExtencion
{
    public static WebApplication Migrate<TContext>(this WebApplication host)
    {
        using var services = host.Services.CreateScope();
        var dbUpService = services.ServiceProvider.GetRequiredService<IDbUpService>();
        var logger = services.ServiceProvider.GetRequiredService<ILogger<TContext>>();

        var result = dbUpService.MigrateDb();

        if (!result.Successful)
        {
            logger.LogInformation($"{result.Error}");
            return host;
        }

        logger.LogInformation("Database migrated succesfully");

        return host;
    }
}
