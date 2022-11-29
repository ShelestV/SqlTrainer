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
}