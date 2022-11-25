using OperationResults.Generic;
using SqlTrainer.Domain.Models;

namespace SqlTrainer.Application.Services;

public interface IAnswerService
{
    Task<IOperationResult<Guid>> AddAsync(CorrectAnswer model);
    // Edit?
    // Delete?
    Task<IOperationResult<CorrectAnswer>> GetAsync(Guid id);
    Task<IOperationResult<IReadOnlyCollection<CorrectAnswer>>> GetByQuestionAsync(Guid questionId);
}