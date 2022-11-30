using SqlTrainer.UserService.Infrastructure.Helpers;

namespace SqlTrainer.UserService.Infrastructure.BusinessLogics;

public sealed class UserBusinessLogic : IUserBusinessLogic
{
    private readonly IUserRepository repository;
    private readonly IPasswordHasher passwordHasher;

    public UserBusinessLogic(IUserRepository repository, IPasswordHasher passwordHasher)
    {
        this.repository = repository;
        this.passwordHasher = passwordHasher;
    }

    public async Task<IOperationResult<Guid>> AddAsync(User model)
    {
        var hashedPassword = passwordHasher.Hash(model.HashedPassword).Result;
        model.HashedPassword = hashedPassword;

        return await repository.AddAsync(model);
    }

    public async Task<IOperationResult<User>> GetByLoginAsync(string login)
    {
        return await this.repository.GetByLoginAsync(login);
    }
}