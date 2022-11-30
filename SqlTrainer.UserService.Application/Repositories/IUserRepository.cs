namespace SqlTrainer.UserService.Application.Repositories;

public interface IUserRepository : IUserService
{
    Task<IOperationResult<Guid>> AddAsync(User model);
    Task<IOperationResult<User>> GetByLoginAsync(string login);
}