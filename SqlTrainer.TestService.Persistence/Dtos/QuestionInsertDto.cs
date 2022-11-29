namespace SqlTrainer.TestService.Persistence.Dtos;

public sealed class QuestionInsertDto
{
    public Guid Id { get; set; }
    public required string Body { get; set; }
    public double MaxMark { get; set; }
}