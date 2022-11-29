namespace SqlTrainer.UserService.Application.BusinessLogics;

public interface ILoginBusinessLogic
{
    Task<IOperationResult<User>> LoginAsync(string login, string password);
}