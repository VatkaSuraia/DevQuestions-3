using DevQuestion.Applicdtion.Questions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DevQuestion.Applicdtion;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddScoped<IQuestionService, QuestionsService>();
        
        return services;
    }
}