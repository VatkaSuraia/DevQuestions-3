using DevQuestion.Applicdtion;
using DevQuestion.Applicdtion.Questions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DevQuestion.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDepencies(this IServiceCollection services)
    {
        services.AddWebDepenncies();
        
        services.AddApplication();
        
        return services;
    }

    private static IServiceCollection AddWebDepenncies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        
        return services;
    }
}

