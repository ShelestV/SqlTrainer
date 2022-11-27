using OperationResults.Generic;
using SqlTrainer.Domain.Models;

namespace SqlTrainer.TokenService.Presentation.Helpers;

public interface ILoginService
{
    Task<IOperationResult<User>> LoginAsync(string login, string password);
}