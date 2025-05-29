using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class CreateFeedbackRequest
{
    [Required]
    public string EventId { get; set; } = null!;

    public string? EventName { get; set; }

    public string? UserId { get; set; }

    public string? UserName { get; set; }

    public string? Content { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    // Category-specific ratings
    [Range(1, 5)]
    public int? VenueRating { get; set; }

    [Range(1, 5)]
    public int? EventOrganizationRating { get; set; }

    [Range(1, 5)]
    public int? StaffSupportRating { get; set; }

    [Range(1, 5)]
    public int? EntertainmentQualityRating { get; set; }

    [Range(1, 5)]
    public int? FoodAndBeveragesRating { get; set; }

    [Range(1, 5)]
    public int? ValueForMoneyRating { get; set; }

    // Event category (e.g., Music, Fashion, Food & Culinary)
    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public bool IsAnonymous { get; set; }
}
