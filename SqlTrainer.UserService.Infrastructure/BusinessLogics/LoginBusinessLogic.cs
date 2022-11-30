using System.Security.Authentication;
using SqlTrainer.UserService.Infrastructure.Helpers;

namespace SqlTrainer.UserService.Infrastructure.BusinessLogics;

public sealed class LoginBusinessLogic : ILoginBusinessLogic
{
    private readonly IUserRepository userRepository;
    private readonly IPasswordHasher passwordHasher;

    public LoginBusinessLogic(IUserRepository repository, IPasswordHasher passwordHasher)
    {
        this.userRepository = repository;
        this.passwordHasher = passwordHasher;
    }
    
    public async Task<IOperationResult<User>> LoginAsync(string login, string password)
    {
        var getUserResult = await this.userRepository.GetByLoginAsync(login);
        // ToDo: Modify OperationResult to be able to check for bad flow and not found using methods, instead of state (state hide as internal)
        if (getUserResult.State != OperationResultState.Ok && getUserResult.State != OperationResultState.NotFound)
            return getUserResult;
        
        var getPasswordResult = this.passwordHasher.Hash(password);

        if (!getPasswordResult.IsCorrect())
            return getPasswordResult.ChangeResultType<string, User>();

        var user = getUserResult.State == OperationResultState.Ok ? getUserResult.Result : null;
        var param = ParamsFactory.CreateSimpleWithResult(Login, user, getPasswordResult.Result);
        return OperationService.DoOperationWithResult(param);
    }
    
    private static User Login(User? user, string password)
    {
        // ToDo: modify OperationResults to be able to throw exception if result is null
        if (user is null)
            throw new AuthenticationException("Incorrect login");
        
        if (!StringComparer.OrdinalIgnoreCase.Equals(password, user.HashedPassword))
            throw new AuthenticationException("Incorrect password");

        return user;
    }
}