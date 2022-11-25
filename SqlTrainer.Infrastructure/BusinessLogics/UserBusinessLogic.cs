using OperationResults.Generic;
using SqlTrainer.Application.BusinessLogics;
using SqlTrainer.Application.Repositories;
using SqlTrainer.Domain.Models;

namespace SqlTrainer.Infrastructure.BusinessLogics;

public sealed class UserBusinessLogic : IUserBusinessLogic
{
    private readonly IUserRepository repository;

    public UserBusinessLogic(IUserRepository repository)
    {
        this.repository = repository;
    }


    public async Task<IOperationResult<IReadOnlyCollection<User>>> GetByLoginAsync(string login)
    {
        return await this.repository.GetByLoginAsync(login);
    }
}