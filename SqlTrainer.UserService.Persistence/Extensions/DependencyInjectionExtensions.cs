using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.Persistence.Extensions;
using SqlTrainer.Postgres;
using SqlTrainer.UserService.Persistence.DbUp;
using SqlTrainer.UserService.Persistence.Repositories;

namespace SqlTrainer.UserService.Persistence.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services, string connectionString)
    {
        services.InjectDatabaseConfiguration(connectionString);

        services.AddTransient<IDbUpService, MigrationHandler>();
        
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}