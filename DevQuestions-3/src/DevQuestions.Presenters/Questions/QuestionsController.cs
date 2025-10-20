using DevQuestion.Applicdtion.Questions;
using DevQuestions.Contracts.Questions;
using Microsoft.AspNetCore.Mvc;

namespace DevQuestions.Presenters.Questions;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{

    private readonly IQuestionService _questionService;
    
    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuestionDto queastionDto,
        CancellationToken cancellationToken)
    {
        var questionId = await _questionService.Create(queastionDto, cancellationToken);
        return Ok(questionId);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetQuestionDto request, 
        CancellationToken cancellationToken)
    {
        return Ok("Questions get");
    }

    [HttpGet("{questionId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid request, 
        CancellationToken cancellationToken)
    {
        return Ok("Questions get");
    }

    [HttpPut("{questionId:guid}")]
    public async Task<IActionResult> UpDate([FromRoute] Guid questionId, 
        [FromBody] UpDateQuestionDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Questions updated");
    }

    [HttpDelete("{questionId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid questionId, 
        CancellationToken cancellationToken)
    {
        return Ok("Questions deleted");
    }

    [HttpPut("{questionId:guid}/solution")]
    public async Task<IActionResult> SelectSolutions([FromRoute] Guid questionId, [FromQuery] Guid answerId,
        CancellationToken cancellationToken)
    {
        return Ok("Questions selected");
    }

    [HttpPost("{questionId:guid}/answers")]
    public async Task<IActionResult> AddAnswer([FromRoute] Guid questionId, 
        [FromBody] AddAnswerDto request, CancellationToken cancellationToken)
    {
        return Ok("Answer added");
    }
}




