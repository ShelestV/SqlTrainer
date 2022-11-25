namespace SqlTrainer.Domain.Models;

public sealed class UserAnswer : Model
{
    public string Text { get; set; } = null!;
    public double Score { get; set; }
    public DateTime AnsweredDateTime { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid TestId { get; set; }
    public Test Test { get; set; } = null!;
    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = null!;
}