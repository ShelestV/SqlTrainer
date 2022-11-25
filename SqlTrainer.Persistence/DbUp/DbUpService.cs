using DbUp;
using DbUp.Engine;
using SqlTrainer.Persistence.Configurations;
using System.Reflection;

namespace SqlTrainer.Persistance.DbUp
{
    public class DbUpService : IDbUpService
    {
        private readonly IDatabaseConfiguration _configuration;

        public DbUpService(IDatabaseConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DatabaseUpgradeResult MigrateDb()
        {
            var connectionString = _configuration.ConnectionString;

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
