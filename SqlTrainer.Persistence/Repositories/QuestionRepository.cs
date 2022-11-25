using Dapper;
using Npgsql;
using OperationResults;
using OperationResults.Generic;
using OperationResults.Services;
using OperationResults.Services.Parameters;
using SqlTrainer.Application.Repositories;
using SqlTrainer.Domain.Models;
using SqlTrainer.Persistence.Configurations;

namespace SqlTrainer.Persistence.Repositories;

public sealed class QuestionRepository : Repository, IQuestionRepository
{
    public QuestionRepository(IDatabaseConfiguration config) : base(config)
    {
    }
    
    public async Task<IOperationResult<Guid>> AddAsync(Question model)
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(async question =>
        {
            question.Id = Guid.NewGuid();
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.ExecuteAsync("call public.\"insert_Question\"(@Id, @Text, @MaxMark)", question);
            return question.Id;
        }, model);
        
        return await OperationService.DoOperationWithResultAsync(param);
    }
    
    public async Task<IOperationResult> DeleteAsync(Guid id)
    {
        var param = AsyncParamsFactory.CreateSimple(async questionId =>
        {
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.ExecuteAsync("call public.\"delete_Question\"(@Id)", questionId);
        }, id);

        return await OperationService.DoOperationAsync(param);
    }

    public async Task<IOperationResult> UpdateAsync(Question model)
    {
        var param = AsyncParamsFactory.CreateSimple(async question =>
        {
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.ExecuteAsync("call public.\"update_Question\"(@Id, @Text, @MaxMark)", question);
        }, model);

        return await OperationService.DoOperationAsync(param);
    }
}