using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SqlTrainer.JwtService.Infrastructure.BusinessLogics;
using SqlTrainer.JwtService.Infrastructure.Configurations;
using SqlTrainer.UserService.Infrastructure.BusinessLogics;
using SqlTrainer.UserService.Infrastructure.Helpers;
using System.Text;

namespace SqlTrainer.UserService.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection InjectBusinessLogics(this IServiceCollection services, string jwtSecretKey)
    {
        services.AddSingleton<IJwtConfiguration>(new JwtConfiguration(jwtSecretKey));

        services.AddTransient<IJwtBusinessLogic, JwtBusinessLogic>();
        
        services.AddTransient<IUserBusinessLogic, UserBusinessLogic>();

        services.AddTransient<ILoginBusinessLogic, LoginBusinessLogic>();

        services.AddTransient<IRegistarationBusinessLogic, RegistrationBusinessLogic>();

        services.AddTransient<IPasswordHasher, PasswordHasher>();

        var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(cfg => 
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = signinKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
}