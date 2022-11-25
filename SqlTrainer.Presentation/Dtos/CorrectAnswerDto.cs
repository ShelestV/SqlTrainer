using SqlTrainer.Presentation.Dtos.Abstract;

namespace SqlTrainer.Presentation.Dtos;

public sealed class CorrectAnswerDto : Dto
{
    public string Text { get; set; } = null!;
    public Guid QuestionId { get; set; }
}