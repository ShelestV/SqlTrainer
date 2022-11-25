using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.Application.BusinessLogics;
using SqlTrainer.Infrastructure.BusinessLogics;

namespace SqlTrainer.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectBusinessLogics(this IServiceCollection services)
    {
        services.AddTransient<IQuestionBusinessLogic, QuestionBusinessLogic>();
        services.AddTransient<ICorrectAnswerBusinessLogic, CorrectAnswerBusinessLogic>();

        return services;
    }
}