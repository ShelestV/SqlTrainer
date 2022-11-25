using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SqlTrainer.TokenService.Presentation.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using SqlTrainer.Application.BusinessLogics;

namespace SqlTrainer.TokenService.Presentation.Extensions;

public static class TokenServiceExtensions
{
    public static IServiceCollection ConfigureJwt(this IServiceCollection services, string key)
    {
        services.AddScoped<IJwtService, JwtService>();

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = signingKey,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
}
