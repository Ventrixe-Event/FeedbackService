namespace Application.Models;

public class FeedbackResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class FeedbackResult<T> : FeedbackResult
{
    public T? Result { get; set; }
}
