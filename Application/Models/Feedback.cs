namespace Application.Models;

public class Feedback
{
    public string Id { get; set; } = null!;
    public string EventId { get; set; } = null!;
    public string? EventName { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }

    // Event category information
    public int? CategoryId { get; set; }
    public string? CategoryName { get; set; }

    public DateTime CreatedAt { get; set; }
    public bool IsAnonymous { get; set; }
}
