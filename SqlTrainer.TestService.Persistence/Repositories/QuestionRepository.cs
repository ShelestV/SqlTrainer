namespace SqlTrainer.TestService.Persistence.Repositories;

public sealed class QuestionRepository : Repository, IQuestionRepository
{
    public QuestionRepository(IDatabaseConfiguration configuration) : base(configuration)
    {
    }

    public async Task<IOperationResult<Guid>> AddAsync(Question model)
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(DoAddAsync, model);
        return await OperationService.DoOperationWithResultAsync(param);
    }

    private async Task<Guid> DoAddAsync(Question model)
    {
        model.Id = Guid.NewGuid();
        
        await using var connection = new NpgsqlConnection(connectionString);
        var dto = new QuestionInsertDto
        {
            Id = model.Id,
            Body = model.Body,
            MaxMark = model.MaxMark
        };
        await connection.ExecuteAsync("call insert_question (@Id, @Body, @MaxMark)", dto);

        return model.Id;
    }
}