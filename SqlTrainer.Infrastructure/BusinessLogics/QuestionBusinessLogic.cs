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

    public async Task<IOperationResult<Guid>> AddAsync(Question model)
    {
        var beforeResult = DoBefore(model);
        if (beforeResult.IsCorrect())
            return await this.repository.AddAsync(model);

        return beforeResult.ToGeneric<Guid>();
    }

    public async Task<IOperationResult> DeleteAsync(Guid id)
    {
        return await repository.DeleteAsync(id);
    }

    public async Task<IOperationResult> UpdateAsync(Question model)
    {
        var beforeResult = DoBefore(model);
        if (beforeResult.IsCorrect())
            return await this.repository.UpdateAsync(model);

        return beforeResult;
    }

    private static IOperationResult DoBefore(Question model)
    {
        var param = ParamsFactory.CreateSimple(Before, model);
        return OperationService.DoOperation(param);
    }
    
    private static void Before(Question model)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model), "Question must be not null");
        
        if (string.IsNullOrWhiteSpace(model.Body))
            throw new ArgumentException("Text of question must be not null or white space");

        if (model.MaxMark <= 0)
            throw new ArgumentException("Max mark must be greater than 0");

        if (model.CorrectAnswer is null)
            throw new ArgumentException("Correct answer must be not null");

        if (string.IsNullOrWhiteSpace(model.CorrectAnswer.Body))
            throw new ArgumentException("Text of correct answer must be not null or white space");
    }
}