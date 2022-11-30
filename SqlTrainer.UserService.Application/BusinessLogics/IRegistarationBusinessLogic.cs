namespace SqlTrainer.UserService.Application.BusinessLogics;

public interface IRegistarationBusinessLogic
{
    Task<IOperationResult<Guid>> RegisterAsync(User model);
}
