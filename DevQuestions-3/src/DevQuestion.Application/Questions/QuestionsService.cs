using DevQuestions.Contracts.Questions;
using DevQuestions.Domain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevQuestion.Applicdtion.Questions;

public class QuestionsService : IQuestionService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;
        
    public QuestionsService(
        IQuestionsRepository questionsRepository,
        ILogger<QuestionsService> logger,
        IValidator<CreateQuestionDto> validator)
    {
       _questionsRepository = questionsRepository;
       _logger = logger;
       _validator = validator;
    }
    
    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    { 
        // проверка валидности

        // валидация входных данных
        var ValidationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        
        if (!ValidationResult.IsValid)
            throw new ValidationException(ValidationResult.Errors);
        
        
        // валидация бизнес логики
        var openUserquestionCount = await _questionsRepository
            .GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);
        
        if (openUserquestionCount > 3)
            throw new Exception("Пользователь не может открыть больше 3 вопросов.");
        
        
        // Создание сущности Question
        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagIds);
        
        // Сохранение сущености Question в БД

        await _questionsRepository.AddAsync(question, cancellationToken);
        
        _logger.LogInformation("Question created with Id {QuestionId}", questionId);
        
        return questionId;
        
        // Логирование об успешном или неуспешном сохранении
    }
    /*
    public async Task<IActionResult> UpDate(
        [FromRoute] Guid questionId,
        [FromBody] UpDateQuestionDto request,
        CancellationToken cancellationToken)
    {
    }

    public async Task<IActionResult> Delete(
        Guid questionId,
        CancellationToken cancellationToken)
    {
    }

   
    public async Task<IActionResult> SelectSolutions(
        Guid questionId,
        Guid answerId,
        CancellationToken cancellationToken)
    {
    }

    public async Task<IActionResult> AddAnswer(
        Guid questionId,
        AddAnswerDto request,
        CancellationToken cancellationToken)
    {
    }
    */
}
