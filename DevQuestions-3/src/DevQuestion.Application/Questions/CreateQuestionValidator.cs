using DevQuestions.Contracts.Questions;
using FluentValidation;

namespace DevQuestion.Applicdtion.Questions;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(350).WithMessage("Заголовок не валидный.");
        
        RuleFor(x => x.Text).NotEmpty().MaximumLength(5000).WithMessage("Текст не валидный.");

        RuleFor(q => q.UserId).NotEmpty();
    }
}