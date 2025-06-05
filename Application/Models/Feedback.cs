/**
 * FeedbackService Feedback DTO - Data Transfer Object
 *
 * Purpose: Data Transfer Object for feedback information exchange between layers
 * Features:
 * - Simplified feedback representation for API responses
 * - Event and category association information
 * - User identification with anonymity support
 * - Rating and content management
 * - Timestamp tracking for audit purposes
 *
 * Architecture: Part of the Application layer in clean architecture
 * - Encapsulates feedback data for transfer between layers
 * - Provides clean API contract for frontend consumption
 * - Abstracts internal entity structure from external interfaces
 * - Supports both anonymous and identified feedback scenarios
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

namespace Application.Models;

/// <summary>
/// Data Transfer Object representing feedback information for API responses.
/// Provides a simplified view of feedback data optimized for frontend consumption
/// while supporting both anonymous and identified feedback scenarios.
/// Includes event and category association for comprehensive feedback analysis.
/// </summary>
public class Feedback
{
    /// <summary>
    /// Gets or sets the unique identifier for this feedback item.
    /// Generated automatically when feedback is created in the system.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier of the event this feedback relates to.
    /// Required field linking feedback to specific events for analysis and reporting.
    /// </summary>
    public string EventId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the human-readable name of the event this feedback relates to.
    /// Optional field for improved user experience and display purposes.
    /// Provides context when viewing feedback without additional event lookups.
    /// </summary>
    public string? EventName { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user who submitted this feedback.
    /// Null when feedback is submitted anonymously.
    /// Used for user-specific feedback tracking and moderation.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user who submitted this feedback.
    /// Null when feedback is submitted anonymously.
    /// Provides human-readable user identification for feedback attribution.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the textual content of the feedback.
    /// Optional field allowing users to provide detailed comments and suggestions.
    /// Supports rich feedback beyond numerical ratings.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets the overall rating for this feedback.
    /// Required field using a 1-5 scale where 1 is poor and 5 is excellent.
    /// Represents the user's overall satisfaction with the event experience.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the event category.
    /// Optional field linking feedback to event categories for analysis.
    /// Enables category-specific feedback aggregation and reporting.
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the human-readable name of the event category.
    /// Optional field providing category context for feedback analysis.
    /// Examples: "Music", "Food & Culinary", "Technology", "Art & Design".
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when this feedback was created.
    /// Automatically set when feedback is submitted to the system.
    /// Used for chronological ordering and temporal analysis of feedback trends.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets whether this feedback was submitted anonymously.
    /// When true, user identification fields (UserId, UserName) should be null.
    /// Supports privacy-conscious feedback submission while maintaining data integrity.
    /// </summary>
    public bool IsAnonymous { get; set; }
}
