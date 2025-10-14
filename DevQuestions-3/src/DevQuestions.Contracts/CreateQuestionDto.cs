namespace DevQuestion.Contracts;

public record CreateQuestionDto(string Title, string Body, Guid UserId, Guid[] TagIds);

public record GetQuestionDto(string Search, Guid[] TagIds, int Page, int Size );

public record UpDateQuestionDto(string Title, string Body, Guid[] TagIds );

public record AddAnswerDto(Guid UserID, string Text);

