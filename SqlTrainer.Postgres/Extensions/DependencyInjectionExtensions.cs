using Microsoft.Extensions.DependencyInjection;

namespace SqlTrainer.Postgres.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectDbUp(this IServiceCollection services)
    {
        return services.AddTransient<IDbUpService, DbUpService>();
    }
}