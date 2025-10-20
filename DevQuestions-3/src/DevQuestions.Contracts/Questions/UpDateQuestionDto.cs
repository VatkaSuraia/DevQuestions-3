namespace DevQuestions.Contracts.Questions;

public record UpDateQuestionDto(string Title, string Body, Guid[] TagIds );
