﻿using Dapper;
using Npgsql;
using OperationResults;
using OperationResults.Generic;
using OperationResults.Services;
using OperationResults.Services.Parameters;
using SqlTrainer.Application.Repositories;
using SqlTrainer.Domain.Models;
using SqlTrainer.Persistence.Configurations;
using SqlTrainer.Persistence.Dtos;

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
        question.CorrectAnswerId = Guid.NewGuid();
        question.CorrectAnswer.Id = Guid.NewGuid();
        
        await using var connection = new NpgsqlConnection(connectionString);
        var dto = new QuestionInsertDto
        {
            Id = question.Id,
            Body = question.Body,
            MaxMark = question.MaxMark,
            AnswerId = question.CorrectAnswerId,
            AnswerBody = question.CorrectAnswer.Body
        };
        await connection.ExecuteAsync("call insert_question (@Id, @Body, @MaxMark, @AnswerId, @AnswerBody)", dto);

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