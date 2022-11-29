using SqlTrainer.UserService.Persistence.Extensions;

namespace SqlTrainer.UserService.Persistence.Repositories;

public sealed class UserRepository : Repository, IUserRepository
{
    public UserRepository(IDatabaseConfiguration config) : base(config)
    {
    }
    
    public async Task<IOperationResult<User>> GetByLoginAsync(string login)
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(DoGetByLoginAsync, login);
        return await OperationService.DoOperationWithResultAsync(param);
    }

    private async Task<User?> DoGetByLoginAsync(string login)
    {
        await using var connection = new NpgsqlConnection(this.connectionString);
        var query = "select * from get_user_by_login (@Login)";
        var dto = new { Login = login };
        var users = await connection.QueryAsync<UserGetDto>(query, dto);
        return users?.FirstOrDefault()?.ToModel();
    }
}