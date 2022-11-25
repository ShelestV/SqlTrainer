namespace SqlTrainer.Persistence.Configurations;

public sealed class DatabaseConfiguration : IDatabaseConfiguration
{
    public string ConnectionString { get; }

    public DatabaseConfiguration(string connectionString)
    {
        this.ConnectionString = connectionString;
    }
}