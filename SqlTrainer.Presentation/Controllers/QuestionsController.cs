using Microsoft.AspNetCore.Mvc;
using OperationResults;
using OperationResults.Web.Extensions;
using SqlTrainer.Application.BusinessLogics;
using SqlTrainer.Presentation.Dtos;
using SqlTrainer.Presentation.Extensions;

namespace SqlTrainer.Presentation.Controllers;

public sealed class QuestionsController : Controller
{
    private readonly IQuestionBusinessLogic logic;
    private readonly ICorrectAnswerBusinessLogic answerLogic;

    public QuestionsController(IQuestionBusinessLogic logic, ICorrectAnswerBusinessLogic answerLogic)
    {
        this.logic = logic;
        this.answerLogic = answerLogic;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] QuestionDto dto)
    {
        // ToDo: move this logic to business logic
        // Check CorrectAnswerModel for valid in QuestionBusinessLogic
        // Call in QuestionRepository also CorrectAnswer insert procedure
        var question = dto.ToModel();
        
        var addQuestionResult = await this.logic.AddAsync(question);
        if (!addQuestionResult.IsCorrect())
            return addQuestionResult.ToActionResult();

        question.Id = addQuestionResult.Result;
        dto.Id = addQuestionResult.Result;
        dto.CorrectAnswer.QuestionId = addQuestionResult.Result;

        var answer = dto.CorrectAnswer.ToModel();

        var addAnswerResult = await this.answerLogic.AddAsync(answer);
        if (!addAnswerResult.IsCorrect())
            return addAnswerResult.ToActionResult();

        question.CorrectAnswerId = addAnswerResult.Result;
        return await this.logic.UpdateAsync(question).ToActionResult();
    }
}