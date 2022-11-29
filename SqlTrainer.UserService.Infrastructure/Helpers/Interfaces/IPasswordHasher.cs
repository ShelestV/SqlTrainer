namespace SqlTrainer.UserService.Infrastructure.Helpers;

public interface IPasswordHasher
{
    IOperationResult<string> Hash(string password);
}