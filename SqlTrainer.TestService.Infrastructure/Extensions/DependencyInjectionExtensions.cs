using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.TestService.Infrastructure.BusinessLogics;

namespace SqlTrainer.TestService.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectBusinessLogics(this IServiceCollection services)
    {
        services.AddTransient<IQuestionBusinessLogic, QuestionBusinessLogic>();

        return services;
    }
}