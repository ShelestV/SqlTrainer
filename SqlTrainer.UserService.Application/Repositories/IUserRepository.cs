namespace SqlTrainer.UserService.Application.Repositories;

public interface IUserRepository : IUserService
{
    Task<IOperationResult<User>> GetByLoginAsync(string login);
}