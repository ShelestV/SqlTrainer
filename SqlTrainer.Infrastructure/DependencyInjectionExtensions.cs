using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.Application.BusinessLogics;
using SqlTrainer.Application.PasswordHasher;
using SqlTrainer.Infrastructure.BusinessLogics;

namespace SqlTrainer.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectBusinessLogics(this IServiceCollection services)
    {
        services.AddTransient<IQuestionBusinessLogic, QuestionBusinessLogic>();
        services.AddTransient<ICorrectAnswerBusinessLogic, CorrectAnswerBusinessLogic>();
        services.AddTransient<IUserBusinessLogic, UserBusinessLogic>();
        services.AddTransient<IPasswordHasher, PasswordHasher.PasswordHasher>();

        return services;
    }
}