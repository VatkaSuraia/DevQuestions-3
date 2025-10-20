using DevQuestions.Contracts.Questions;

namespace DevQuestion.Applicdtion.Questions;

public interface IQuestionService
{
    Task<Guid> Create(CreateQuestionDto queastionDto, CancellationToken cancellationToken);
}