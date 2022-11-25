using OperationResults;
using OperationResults.Generic;
using OperationResults.Services;
using OperationResults.Services.Parameters;
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

    private static void BeforeAdd(Question model)
    {
        if (string.IsNullOrWhiteSpace(model.Text))
            throw new ArgumentException("Text of question must be not null or empty");

        if (model.MaxMark <= 0)
            throw new ArgumentException("Max mark must be greater than 0");
    }
    
    public async Task<IOperationResult<Guid>> AddAsync(Question model)
    {
        var param = ParamsFactory.CreateSimple(BeforeAdd, model);
        var beforeResult = OperationService.DoOperation(param);
        
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