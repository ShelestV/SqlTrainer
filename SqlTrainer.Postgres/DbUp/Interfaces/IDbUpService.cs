using DbUp.Engine;

namespace SqlTrainer.Postgres;

public interface IDbUpService
{
    DatabaseUpgradeResult Migrate();
}