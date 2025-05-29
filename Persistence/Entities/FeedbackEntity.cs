using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class FeedbackEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string EventId { get; set; } = null!;

    public string? EventName { get; set; }

    public string? UserId { get; set; }

    public string? UserName { get; set; }

    public string? Content { get; set; }

    // Overall rating (1-5)
    public int Rating { get; set; }

    // Event category
    public int? CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public CategoryEntity? Category { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsAnonymous { get; set; }
}
