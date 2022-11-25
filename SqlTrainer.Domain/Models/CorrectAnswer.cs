namespace SqlTrainer.Domain.Models;

public sealed class CorrectAnswer : Model
{
    public string Text { get; set; } = null!;
    // Some fields to define correct answer: a list of correct columns or keywords
    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = null!; // Do we need navigation fields?
}