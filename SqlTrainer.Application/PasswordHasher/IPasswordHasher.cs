using OperationResults.Generic;

namespace SqlTrainer.Application.PasswordHasher;

public interface IPasswordHasher
{
    IOperationResult<string> HashPassword(string password);
}
