using OperationResults.Generic;

namespace SqlTrainer.JwtService.Infrastructure.BusinessLogics;

public interface IJwtBusinessLogic
{
    IOperationResult<string> Generate(IDictionary<string, string> claims);
}