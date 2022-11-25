using SqlTrainer.Persistence.Configurations;

namespace SqlTrainer.Persistence.Repositories;

public abstract class Repository
{
    protected readonly string connectionString;

    protected Repository(IDatabaseConfiguration config)
    {
        this.connectionString = config.ConnectionString;
    }
}