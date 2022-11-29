namespace SqlTrainer.TestService.Presentation.Dtos;

public sealed class QuestionDto
{
    public required string Body { get; set; }
    public double MaxMark { get; set; }
    public required string AnswerBody { get; set; }
}