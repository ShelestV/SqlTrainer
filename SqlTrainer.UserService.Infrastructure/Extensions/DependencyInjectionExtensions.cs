using Microsoft.Extensions.DependencyInjection;
using SqlTrainer.JwtService.Infrastructure.Configurations;
using SqlTrainer.UserService.Infrastructure.BusinessLogics;
using SqlTrainer.UserService.Infrastructure.Helpers;

namespace SqlTrainer.UserService.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectBusinessLogics(this IServiceCollection services, string jwtSecretKey)
    {
        services.AddSingleton<IJwtConfiguration>(new JwtConfiguration(jwtSecretKey));
        
        services.AddTransient<IUserBusinessLogic, UserBusinessLogic>();

        services.AddTransient<IPasswordHasher, PasswordHasher>();

        return services;
    }
}