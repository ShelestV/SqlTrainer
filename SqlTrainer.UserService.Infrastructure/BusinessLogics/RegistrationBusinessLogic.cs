using SqlTrainer.UserService.Application.BusinessLogics;
using SqlTrainer.UserService.Infrastructure.Helpers;

namespace SqlTrainer.UserService.Infrastructure.BusinessLogics;

public class RegistrationBusinessLogic : IRegistarationBusinessLogic
{
    private readonly IUserRepository userRepository;
    private readonly IPasswordHasher passwordHasher;

    public RegistrationBusinessLogic(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        this.userRepository = userRepository;
        this.passwordHasher = passwordHasher;
    }

    public async Task<IOperationResult<Guid>> RegisterAsync(User model)
    {
        var userResult = await userRepository.GetByLoginAsync(model.Login);

        if (userResult.IsCorrect())
            throw new Exception("User with the same login already exists");

        var hashResult = passwordHasher.Hash(model.HashedPassword);

        if (!hashResult.IsCorrect())
            return hashResult.ChangeResultType<string, Guid>();

        return await userRepository.AddAsync(model);
    }
}
