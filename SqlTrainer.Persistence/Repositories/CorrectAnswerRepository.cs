using Dapper;
using Npgsql;
using OperationResults.Generic;
using OperationResults.Services;
using OperationResults.Services.Parameters;
using SqlTrainer.Application.Repositories;
using SqlTrainer.Domain.Models;
using SqlTrainer.Persistence.Configurations;

namespace SqlTrainer.Persistence.Repositories;

public sealed class CorrectAnswerRepository : Repository, ICorrectAnswerRepository
{
    public CorrectAnswerRepository(IDatabaseConfiguration config) : base(config)
    {
    }

    public async Task<IOperationResult<Guid>> AddAsync(CorrectAnswer model)
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(async answer =>
        {
            answer.Id = Guid.NewGuid();
            await using var connection = new NpgsqlConnection(this.connectionString);
            await connection.ExecuteAsync("call public.\"insert_CorrectAnswer\"(@Id, @Text, @QuestionId)", answer);
            return answer.Id;
        }, model);

        return await OperationService.DoOperationWithResultAsync(param);
    }
}