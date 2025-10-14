using DevQuestion.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DevQuestions.Presenters;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuestionDto queastionDto,
        CancellationToken cancellationToken)
    {
        return Ok("Questions created");
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetQuestionDto request, CancellationToken cancellationToken)
    {
        return Ok("Questions get");
    }

    [HttpGet("{questionId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid request, CancellationToken cancellationToken)
    {
        return Ok("Questions get");
    }

    [HttpPut("{questionId:guid}")]
    public async Task<IActionResult> UpDate([FromRoute] Guid questionId, [FromBody] UpDateQuestionDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Questions updated");
    }

    [HttpDelete("{questionId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid questionId, CancellationToken cancellationToken)
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
    public async Task<IActionResult> AddAnswer([FromRoute] Guid questionId, [FromBody] AddAnswerDto request, CancellationToken cancellationToken)
    {
        return Ok("Answer added");
    }
}




