using SqlTrainer.TestService.Domain.Models;

namespace SqlTrainer.TestService.Infrastructure.BusinessLogics;

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

    private static IOperationResult DoBefore(Question model)
    {
        var param = ParamsFactory.CreateSimple(Before, model);
        return OperationService.DoOperation(param);
    }
    
    private static void Before(Question question)
    {
        if (question is null)
            throw new ArgumentNullException(nameof(question), "Question must be not null");
        
        if (string.IsNullOrWhiteSpace(question.Body))
            throw new ArgumentException("Text of question must be not null or white space");

        if (question.MaxMark <= 0)
            throw new ArgumentException("Max mark must be greater than 0");
    }
}