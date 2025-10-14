namespace DevQuestion.Contracts;

public record UpDateQuestionDto(string Title, string Body, Guid[] TagIds );
