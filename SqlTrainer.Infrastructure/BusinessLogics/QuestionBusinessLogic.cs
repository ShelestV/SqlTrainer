using OperationResults;
using OperationResults.Generic;
using SqlTrainer.Domain.Models;
using SqlTrainer.Application.BusinessLogics;
using SqlTrainer.Application.Repositories;

namespace SqlTrainer.Infrastructure.BusinessLogics;

public sealed class QuestionBusinessLogic : IQuestionBusinessLogic
{
    private readonly IQuestionRepository repository;

    public QuestionBusinessLogic(IQuestionRepository repository)
    {
        this.repository = repository;
    }

    private Task<IOperationResult> BeforeAddAsync(Question model)
    {
        var result = OperationResultFactory.Create();
        result.Done();
        return Task.FromResult(result);
    }
    
    public async Task<IOperationResult<Guid>> AddAsync(Question model)
    {
        var beforeResult = await this.BeforeAddAsync(model);
        if (beforeResult.IsCorrect())
            return await this.repository.AddAsync(model);

        return beforeResult.ToGeneric<Guid>();
    }

    public async Task<IOperationResult> DeleteAsync(Guid id)
    {
        return await repository.DeleteAsync(id);
    }

    private Task<IOperationResult> BeforeUpdateAsync(Question model)
    {
        var result = OperationResultFactory.Create();
        result.Done();
        return Task.FromResult(result);
    }
    
    public async Task<IOperationResult> UpdateAsync(Question model)
    {
        var beforeResult = await this.BeforeUpdateAsync(model);
        if (beforeResult.IsCorrect())
            return await this.repository.UpdateAsync(model);

        return beforeResult;
    }
}