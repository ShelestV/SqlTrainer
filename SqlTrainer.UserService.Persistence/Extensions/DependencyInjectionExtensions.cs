using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.Persistence.Extensions;
using SqlTrainer.Postgres.Extensions;
using SqlTrainer.UserService.Persistence.Repositories;

namespace SqlTrainer.UserService.Persistence.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services, string connectionString)
    {
        services = services
            .InjectDatabaseConfiguration(connectionString)
            .InjectDbUp();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}