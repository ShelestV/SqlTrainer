using Microsoft.AspNetCore.Mvc;
using OperationResults.Web.Extensions;
using SqlTrainer.Application.BusinessLogics;
using SqlTrainer.Presentation.Dtos;
using SqlTrainer.Presentation.Extensions;

namespace SqlTrainer.Presentation.Controllers;

public sealed class QuestionsController : Controller
{
    private readonly IQuestionBusinessLogic logic;

    public QuestionsController(IQuestionBusinessLogic logic)
    {
        this.logic = logic;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] QuestionDto questionDto)
    {
        return await this.logic.AddAsync(questionDto.ToModel()).ToActionResult();
    }
}