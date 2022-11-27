using OperationResults.Generic;
using SqlTrainer.Domain.Models;

namespace SqlTrainer.Application.Services;

public interface IUserService
{
    Task<IOperationResult<IReadOnlyCollection<User>>> GetByLoginAsync(string login);
}