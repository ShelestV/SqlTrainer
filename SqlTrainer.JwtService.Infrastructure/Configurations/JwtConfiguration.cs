namespace SqlTrainer.JwtService.Infrastructure.Configurations;

public sealed class JwtConfiguration : IJwtConfiguration
{
    public string SecretKey { get; }

    public JwtConfiguration(string secretKey)
    {
        this.SecretKey = secretKey;
    }
}