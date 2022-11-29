using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SqlTrainer.Presentation.Extensions;

public static class ConfigureModelStateErrors
{
    public static IServiceCollection ConfigureModelStateErrorsBehavior(this IServiceCollection services)
    {
        services.AddMvcCore()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                                                        new BadRequestObjectResult(context.ModelState.Values
                                                                  .SelectMany(el => el.Errors.Select(e => e.ErrorMessage)).ToList());
            });

        return services;
    }
}
