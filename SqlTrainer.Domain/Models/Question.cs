namespace SqlTrainer.Domain.Models;

public sealed class Question : Model
{
    public string Text { get; set; } = null!;
    public double MaxMark { get; set; }
    public Guid CorrectAnswerId { get; set; }
    public CorrectAnswer CorrectAnswer { get; set; } = null!;
    public IReadOnlyCollection<Test> Tests = new List<Test>();
}