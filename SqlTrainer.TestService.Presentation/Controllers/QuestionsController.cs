namespace SqlTrainer.TestService.Presentation.Controllers;

public sealed class QuestionsController : Controller
{
    private readonly IQuestionBusinessLogic questionLogic;

    public QuestionsController(IQuestionBusinessLogic questionLogic)
    {
        this.questionLogic = questionLogic;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] QuestionDto dto)
    {
        return await this.questionLogic.AddAsync(dto.ToModel()).ToActionResult();
    }
}