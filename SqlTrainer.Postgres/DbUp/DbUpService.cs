using System.Reflection;
using DbUp;
using DbUp.Engine;
using SqlTrainer.Persistence.Configurations;

namespace SqlTrainer.Postgres;

public abstract class DbUpService : IDbUpService
{
    private readonly IDatabaseConfiguration configuration;
    protected abstract Assembly MigrationAssembly { get; }
    
    protected DbUpService(IDatabaseConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public DatabaseUpgradeResult Migrate()
    {
        var connectionString = configuration.ConnectionString;

        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(this.MigrationAssembly)
            .LogToConsole()
            .Build();

        var result = upgrader.PerformUpgrade();

        return result;
    }
}