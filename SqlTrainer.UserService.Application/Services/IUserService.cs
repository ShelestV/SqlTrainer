namespace SqlTrainer.UserService.Application.Services;

public interface IUserService
{
    Task<IOperationResult<Guid>> RegisterAsync(User model);
}