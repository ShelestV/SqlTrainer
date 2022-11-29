using SqlTrainer.TestService.Domain.Models;

namespace SqlTrainer.TestService.Presentation.Extensions;

public static class DtoExtensions
{
    public static Question ToModel(this QuestionDto dto)
    {
        return new Question
        {
            Id = Guid.Empty,
            Body = dto.Body,
            MaxMark = dto.MaxMark
        };
    }
}