using SqlTrainer.Persistence.Configurations;

namespace SqlTrainer.Persistence.Repositories;

public abstract class Repository
{
    protected readonly string connectionString;

    protected Repository(IDatabaseConfiguration configuration)
    {
        this.connectionString = configuration.ConnectionString;
    }
}