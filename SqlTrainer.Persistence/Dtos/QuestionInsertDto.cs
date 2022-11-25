namespace SqlTrainer.Persistence.Dtos;

public sealed class QuestionInsertDto : Dto
{
    public string Body { get; set; } = null!;
    public double MaxMark { get; set; }
    public Guid AnswerId { get; set; }
    public string AnswerBody { get; set; } = null!;
}