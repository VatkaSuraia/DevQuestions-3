using DevQuestions.Domain.Questions;

namespace DevQuestion.Applicdtion.Questions;

public interface IQuestionsRepository
{
    Task<Guid> AddAsync(Question question, CancellationToken cancellationToken);

    Task<Guid> UpdateAsync(Question question, CancellationToken cancellationToken);
    
    Task<Guid> DeleteAsync(Guid questionId, CancellationToken cancellationToken);

    Task<Question> GetByIdAsync(Guid question, CancellationToken cancellationToken);

    Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken);
}