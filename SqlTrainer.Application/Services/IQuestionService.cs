using OperationResults;
using OperationResults.Generic;
using SqlTrainer.Domain.Models;

namespace SqlTrainer.Application.Services;

public interface IQuestionService
{
    Task<IOperationResult<Guid>> AddAsync(Question model);
    Task<IOperationResult> DeleteAsync(Guid id);
    Task<IOperationResult> UpdateAsync(Question model);
}