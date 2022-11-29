using System.Reflection;
using DbUp;
using DbUp.Engine;
using SqlTrainer.Persistence.Configurations;

namespace SqlTrainer.Postgres;

public sealed class DbUpService : IDbUpService
{
    private readonly IDatabaseConfiguration configuration;

    public DbUpService(IDatabaseConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public DatabaseUpgradeResult Migrate(Assembly migrationAssembly)
    {
        var connectionString = configuration.ConnectionString;

        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(migrationAssembly)
            .LogToConsole()
            .Build();

        var result = upgrader.PerformUpgrade();

        return result;
    }
}