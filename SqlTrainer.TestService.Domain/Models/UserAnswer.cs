namespace SqlTrainer.TestService.Domain.Models;

public sealed class UserAnswer : Model
{
    public required string Body { get; set; }
    public double Score { get; set; }
    public DateTime AnsweredAt { get; set; }
    public Guid UserId { get; set; }
    public Guid TestId { get; set; }
    public required Test Test { get; set; }
    public Guid QuestionId { get; set; }
    public required Question Question { get; set; }
}