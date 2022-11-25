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
            Text = dto.Text,
            MaxMark = dto.MaxMark,
            CorrectAnswerId = null,
        };
    }

    public static CorrectAnswer ToModel(this CorrectAnswerDto dto)
    {
        return new CorrectAnswer
        {
            Id = dto.Id,
            Text = dto.Text,
            QuestionId = dto.QuestionId,
        };
    }
}