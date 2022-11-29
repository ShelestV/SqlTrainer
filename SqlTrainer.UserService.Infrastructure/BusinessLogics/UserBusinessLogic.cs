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

    public async Task<IOperationResult<Guid>> RegisterAsync(User model)
    {
        var userResult = await repository.GetByLoginAsync(model.Login);

        if (userResult.State == OperationResultState.Ok)
            throw new Exception("User with the same login already exists");

        var hashedPassword = passwordHasher.Hash(model.HashedPassword).Result;
        model.HashedPassword = hashedPassword;

        return await repository.RegisterAsync(model);
    }
}