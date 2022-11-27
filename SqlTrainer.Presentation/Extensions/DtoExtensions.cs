using SqlTrainer.Domain.Models;
using SqlTrainer.Presentation.Dtos;

namespace SqlTrainer.Presentation.Extensions;

public static class DtoExtensions
{
    public static Question ToModel(this QuestionDto dto)
    {
        return new Question
        {
            Id = dto.Id,
            Body = dto.Body,
            MaxMark = dto.MaxMark,
            CorrectAnswerId = dto.CorrectAnswerId,
            CorrectAnswer = new CorrectAnswer()
            {
                Id = dto.CorrectAnswerId,
                Body = dto.Body
            }
        };
    }
}