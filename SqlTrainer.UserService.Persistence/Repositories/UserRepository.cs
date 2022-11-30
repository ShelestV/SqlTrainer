using SqlTrainer.UserService.Domain.Models;
using SqlTrainer.UserService.Persistence.Extensions;

namespace SqlTrainer.UserService.Persistence.Repositories;

public sealed class UserRepository : Repository, IUserRepository
{
    public UserRepository(IDatabaseConfiguration config) : base(config)
    {
    }

    public async Task<IOperationResult<Guid>> AddAsync(User model)
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(DoAddAsync, model);
        return await OperationService.DoOperationWithResultAsync(param);
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


    private async Task<Guid> DoAddAsync(User user)
    {
        await using var connection = new NpgsqlConnection(this.connectionString);
        var query = "call insert_user (@Id, @Name, @Login, @HashPassword, @RoleId, @GroupId, @FaceImage, @Rate)";
        var dto = new UserInsertDto
        {
            Id = user.Id,
            Name = user.Name,
            Login = user.Login,
            HashPassword = user.HashedPassword,
            RoleId = user.RoleId,
            GroupId = user.GroupId,
            FaceImage = user.FaceImage,
            Rate = user.Rate,
        };

        await connection.ExecuteAsync(query, dto);

        return user.Id;
    }
}