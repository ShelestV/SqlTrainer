using SqlTrainer.Presentation.Dtos.Abstract;

namespace SqlTrainer.Presentation.Dtos;

public sealed class QuestionDto : Dto
{
    public string Body { get; set; } = null!;
    public double MaxMark { get; set; }
    public Guid CorrectAnswerId { get; set; }
    public string CorrectAnswerBody { get; set; } = null!;
}