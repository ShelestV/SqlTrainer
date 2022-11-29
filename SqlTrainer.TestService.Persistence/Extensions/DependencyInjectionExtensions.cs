using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.Persistence.Extensions;
using SqlTrainer.Postgres;
using SqlTrainer.TestService.Persistence.DbUp;
using SqlTrainer.TestService.Persistence.Repositories;

namespace SqlTrainer.TestService.Persistence.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services, string connectionString)
    {
        services.InjectDatabaseConfiguration(connectionString);

        services.AddTransient<IDbUpService, MigrationHandler>();

        services.AddScoped<IQuestionRepository, QuestionRepository>();
        
        return services;
    }
}