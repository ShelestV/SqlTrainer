using SqlTrainer.Presentation.Dtos.Abstract;

namespace SqlTrainer.Presentation.Dtos;

public sealed class QuestionDto : Dto
{
    public string Text { get; set; } = null!;
    public double MaxMark { get; set; }
    public Guid CorrectAnswerId { get; set; }
    public CorrectAnswerDto CorrectAnswer { get; set; } = null!;
}