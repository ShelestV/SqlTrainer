using DbUp;
using DbUp.Engine;
using SqlTrainer.Persistence.Configurations;
using System.Reflection;

namespace SqlTrainer.Persistence.DbUp
{
    public class DbUpService : IDbUpService
    {
        private readonly IDatabaseConfiguration configuration;

        public DbUpService(IDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DatabaseUpgradeResult MigrateDb()
        {
            var connectionString = configuration.ConnectionString;

            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            return result;
        }
    }
}
