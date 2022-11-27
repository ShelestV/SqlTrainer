namespace SqlTrainer.Domain.Models;

public sealed class Question : Model
{
    public string Body { get; set; } = null!;
    public double MaxMark { get; set; }
    public Guid CorrectAnswerId { get; set; }
    public CorrectAnswer? CorrectAnswer { get; set; }
    public IReadOnlyCollection<Test> Tests = new List<Test>();
}