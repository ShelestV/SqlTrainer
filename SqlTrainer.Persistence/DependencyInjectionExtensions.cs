using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.Application.Repositories;
using SqlTrainer.Persistence.DbUp;
using SqlTrainer.Persistence.Configurations;
using SqlTrainer.Persistence.Repositories;

namespace SqlTrainer.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDatabaseConfiguration>(new DatabaseConfiguration(connectionString));

        services.AddTransient<IDbUpService, DbUpService>();

        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<ICorrectAnswerRepository, CorrectAnswerRepository>();

        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}