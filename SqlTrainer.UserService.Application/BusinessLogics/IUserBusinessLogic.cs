namespace SqlTrainer.UserService.Application.BusinessLogics;

public interface IUserBusinessLogic : IUserService
{
    Task<IOperationResult<User>> GetByLoginAsync(string login);
}