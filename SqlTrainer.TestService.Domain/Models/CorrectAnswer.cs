namespace SqlTrainer.TestService.Domain.Models;

public sealed class CorrectAnswer : Model
{
    public required string Body { get; set; }
    public Guid QuestionId { get; set; }
    public required Question Question { get; set; }
}