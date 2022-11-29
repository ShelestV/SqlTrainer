using System.Reflection;
using SqlTrainer.Postgres;

namespace SqlTrainer.TestService.Persistence.DbUp;

public sealed class MigrationHandler : DbUpService
{
    protected override Assembly MigrationAssembly { get; }
    
    public MigrationHandler(IDatabaseConfiguration configuration) : base(configuration)
    {
        this.MigrationAssembly = Assembly.GetExecutingAssembly();
    }
}