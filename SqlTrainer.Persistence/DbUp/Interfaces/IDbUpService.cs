using DbUp.Engine;

namespace SqlTrainer.Persistance.DbUp;

public interface IDbUpService
{
    DatabaseUpgradeResult MigrateDb();
}
