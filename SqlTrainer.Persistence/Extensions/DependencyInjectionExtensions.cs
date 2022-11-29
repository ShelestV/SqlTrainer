using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.Persistence.Configurations;

namespace SqlTrainer.Persistence.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectDatabaseConfiguration(this IServiceCollection services, string connectionString)
    {
        return services.AddSingleton<IDatabaseConfiguration>(new DatabaseConfiguration(connectionString));
    } 
}