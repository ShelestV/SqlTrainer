using OperationResults.Generic;
using SqlTrainer.Domain.Models;

namespace SqlTrainer.TokenService.Presentation.Helpers;

public interface IJwtService
{
    IOperationResult<string> Generate(User user);
}
