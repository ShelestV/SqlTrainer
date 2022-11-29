namespace SqlTrainer.JwtService.Infrastructure.Configurations;

public interface IJwtConfiguration
{
    string SecretKey { get; }
}