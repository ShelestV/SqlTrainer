using OperationResults.Generic;
using SqlTrainer.Application.BusinessLogics;
using SqlTrainer.Application.PasswordHasher;
using SqlTrainer.Application.Repositories;
using SqlTrainer.Domain.Models;

namespace SqlTrainer.Infrastructure.BusinessLogics;

public sealed class UserBusinessLogic : IUserBusinessLogic
{
    private readonly IUserRepository repository;
    private readonly IPasswordHasher passwordHasher;

    public UserBusinessLogic(IUserRepository repository, IPasswordHasher passwordHasher)
    {
        this.repository = repository;
        this.passwordHasher = passwordHasher;
    }


    // ToDo: Hash password before adding new user to db

    public async Task<IOperationResult<IReadOnlyCollection<User>>> GetByLoginAsync(string login)
    {
        return await this.repository.GetByLoginAsync(login);
    }
}