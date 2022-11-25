using OperationResults.Generic;
using SqlTrainer.Domain.Models;

namespace SqlTrainer.Application.Services;

public interface ICorrectAnswerService
{
    Task<IOperationResult<Guid>> AddAsync(CorrectAnswer model);
}