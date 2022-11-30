using SqlTrainer.UserService.Application.BusinessLogics;

namespace SqlTrainer.UserService.Infrastructure.BusinessLogics;

public class RegistrationBusinessLogic : IRegistarationBusinessLogic
{
    private readonly IUserBusinessLogic userBusinessLogic;

    public RegistrationBusinessLogic(IUserBusinessLogic userBusinessLogic)
    {
        this.userBusinessLogic = userBusinessLogic;
    }

    public async Task<IOperationResult<Guid>> RegisterAsync(User model)
    {
        var userResult = await userBusinessLogic.GetByLoginAsync(model.Login);

        if (userResult.IsCorrect())
            throw new Exception("User with the same login already exists");

        return await userBusinessLogic.AddAsync(model);
    }
}
