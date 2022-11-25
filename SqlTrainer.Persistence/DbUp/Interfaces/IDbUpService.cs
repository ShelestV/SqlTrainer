using DbUp.Engine;

namespace SqlTrainer.Persistence.DbUp;

public interface IDbUpService
{
    DatabaseUpgradeResult MigrateDb();
}
