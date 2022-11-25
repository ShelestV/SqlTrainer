using SqlTrainer.Persistence.Configurations;
using SqlTrainer.Persistence.Repositories;

namespace SqlTrainer.Persistence.Tests;

public sealed class UserRepositoryTests
{
    private const string ConnectionString = "Host=localhost:5432;Username=postgres;Password=qwerty;Database=SqlTrainer";

    [Fact]
    public async Task GetUserByLoginAsync_Success_Test()
    {
        var dbConfig = new DatabaseConfiguration(ConnectionString);
        var repository = new UserRepository(dbConfig);

        var result = await repository.GetByLoginAsync("test");

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        var user = result.Result.FirstOrDefault();
        user.Should().NotBeNull();
        user!.Id.Should().Be(Guid.Parse("248e8789-a264-40a6-a886-d828c5b6c344"));
    }
}