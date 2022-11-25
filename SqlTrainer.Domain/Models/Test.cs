namespace SqlTrainer.Domain.Models;

public sealed class Test : Model
{
    public string Name { get; set; } = null!;
    public Guid TopicId { get; set; }
    public Topic Topic { get; set; } = null!;
    public IReadOnlyCollection<Question> Questions { get; set; } = new List<Question>(); // Do we need navigation fields?
}