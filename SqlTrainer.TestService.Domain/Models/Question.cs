namespace SqlTrainer.TestService.Domain.Models;

public sealed class Question : Model
{
    public required string Body { get; set; }
    public double MaxMark { get; set; }
    public IReadOnlyCollection<Test> Tests { get; set; } = new List<Test>();
}