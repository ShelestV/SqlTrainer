using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.Persistence.Extensions;
using SqlTrainer.Postgres.Extensions;
using SqlTrainer.TestService.Persistence.Repositories;

namespace SqlTrainer.TestService.Persistence.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services, string connectionString)
    {
        services = services
            .InjectDatabaseConfiguration(connectionString)
            .InjectDbUp();

        services.AddScoped<IQuestionRepository, QuestionRepository>();
        
        return services;
    }
}