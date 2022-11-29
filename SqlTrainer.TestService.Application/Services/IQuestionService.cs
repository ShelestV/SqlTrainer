namespace SqlTrainer.TestService.Application.Services;

public interface IQuestionService
{
    Task<IOperationResult<Guid>> AddAsync(Question model);
}