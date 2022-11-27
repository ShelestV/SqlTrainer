using Dapper;
using Npgsql;
using OperationResults.Generic;
using OperationResults.Services;
using OperationResults.Services.Parameters;
using SqlTrainer.Application.Repositories;
using SqlTrainer.Domain.Models;
using SqlTrainer.Persistence.Configurations;
using SqlTrainer.Persistence.Dtos;
using SqlTrainer.Persistence.Extensions;

namespace SqlTrainer.Persistence.Repositories;

public sealed class UserRepository : Repository, IUserRepository
{
    public UserRepository(IDatabaseConfiguration config) : base(config)
    {
    }

    public async Task<IOperationResult<IReadOnlyCollection<User>>> GetByLoginAsync(string login)
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(DoGetByLoginAsync, login);
        return await OperationService.DoOperationWithResultAsync(param);
    }

    private async Task<IReadOnlyCollection<User>?> DoGetByLoginAsync(string login)
    {
        await using var connection = new NpgsqlConnection(this.connectionString);
        var dto = new
        {
            Login = login
        };
        var users = await connection.QueryAsync<UserGetDto>("select * from get_user_by_login (@Login)", dto);
        return users?.Select(user => user.ToModel()).ToList();
    }
}