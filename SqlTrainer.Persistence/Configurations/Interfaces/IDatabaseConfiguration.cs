namespace SqlTrainer.Persistence.Configurations;

public interface IDatabaseConfiguration
{
    string ConnectionString { get; }
}