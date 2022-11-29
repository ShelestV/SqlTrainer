namespace SqlTrainer.TestService.Domain.Models;

public sealed class Test : Model
{
    public required string Name { get; set; }
    public IReadOnlyCollection<Question> Questions { get; set; } = new List<Question>();
}