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
        var param = AsyncParamsFactory.CreateSimpleWithResult(DoAddAsync, model);
        return await OperationService.DoOperationWithResultAsync(param);
    }

    private async Task<Guid> DoAddAsync(Question question)
    {
        question.Id = Guid.NewGuid();
        question.CorrectAnswer!.QuestionId = question.Id;
            
        await using var connection = new NpgsqlConnection(connectionString);
        // ToDo: call these queries on db side
        await connection.ExecuteAsync("call public.\"insert_Question\"(@Id, @Text, @MaxMark)", question);
        await connection.ExecuteAsync("call public.\"insert_CorrectAnswer\"(@Id, @Text, @QuestionId)", question.CorrectAnswer);
        await connection.ExecuteAsync("call public.\"update_Question_AddCorrectAnswerId\"(@Id, @CorrectAnswerId)", question);
            
        return question.Id;
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