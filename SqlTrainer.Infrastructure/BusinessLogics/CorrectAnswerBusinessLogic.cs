using OperationResults.Generic;
using SqlTrainer.Application.BusinessLogics;
using SqlTrainer.Application.Repositories;
using SqlTrainer.Domain.Models;

namespace SqlTrainer.Infrastructure.BusinessLogics;

public sealed class CorrectAnswerBusinessLogic : ICorrectAnswerBusinessLogic
{
    private readonly ICorrectAnswerRepository repository;

    public CorrectAnswerBusinessLogic(ICorrectAnswerRepository repository)
    {
        this.repository = repository;
    }
    
    public async Task<IOperationResult<Guid>> AddAsync(CorrectAnswer model)
    {
        return await this.repository.AddAsync(model);
    }
}