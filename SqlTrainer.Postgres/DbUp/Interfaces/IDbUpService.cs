using DbUp.Engine;
using System.Reflection;

namespace SqlTrainer.Postgres;

public interface IDbUpService
{
    DatabaseUpgradeResult Migrate(Assembly migrationAssembly);
}