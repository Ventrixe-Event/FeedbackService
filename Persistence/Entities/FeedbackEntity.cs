/**
 * FeedbackService Feedback Entity - Database Model
 *
 * Purpose: Entity Framework Core entity representing feedback data in the database
 * Features:
 * - Simplified feedback model with essential properties
 * - Event and category association with navigation properties
 * - User identification with anonymity support
 * - Single overall rating system (1-5 scale)
 * - Automatic timestamp tracking and GUID generation
 *
 * Architecture: Part of the Persistence layer in clean architecture
 * - Maps to feedback table in the database
 * - Provides navigation property to CategoryEntity
 * - Uses data annotations for column configuration
 * - Supports both anonymous and identified feedback scenarios
 *
 * Database Schema:
 * - Primary key: Id (string/GUID)
 * - Foreign key: CategoryId -> CategoryEntity
 * - Timestamps: CreatedAt (datetime2)
 * - Text fields: EventId, EventName, UserId, UserName, Content
 * - Numeric fields: Rating (1-5), CategoryId
 * - Boolean fields: IsAnonymous
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

/// <summary>
/// Entity Framework Core entity representing feedback items in the database.
/// Provides a simplified feedback model focused on essential feedback collection.
/// Supports both anonymous and identified feedback with event and category associations.
/// Uses Entity Framework navigation properties for related data access.
/// </summary>
public class FeedbackEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for this feedback entity.
    /// Uses GUID string format for globally unique identification.
    /// Automatically generated when new instances are created.
    /// Serves as the primary key in the database table.
    /// </summary>
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Gets or sets the unique identifier of the event this feedback relates to.
    /// Required field linking feedback to specific events for analysis and reporting.
    /// Used for event-specific feedback retrieval and aggregation.
    /// </summary>
    public string EventId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the human-readable name of the event this feedback relates to.
    /// Optional field that provides context and improves query performance.
    /// Denormalized for efficiency to avoid joins when displaying feedback lists.
    /// </summary>
    public string? EventName { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user who submitted this feedback.
    /// Null when feedback is submitted anonymously to respect user privacy.
    /// Used for user-specific feedback tracking and moderation capabilities.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user who submitted this feedback.
    /// Null when feedback is submitted anonymously to respect user privacy.
    /// Denormalized for efficiency to avoid user service lookups during display.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the textual content of the feedback.
    /// Optional field allowing users to provide detailed comments and suggestions.
    /// Supports rich qualitative feedback beyond numerical ratings.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets the overall rating for this feedback.
    /// Uses a 1-5 scale where 1 represents poor experience and 5 represents excellent experience.
    /// Simplified rating system focusing on overall satisfaction measurement.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the event category.
    /// Optional field linking feedback to event categories for segmented analysis.
    /// Foreign key relationship to CategoryEntity for structured categorization.
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category entity associated with this feedback.
    /// Navigation property providing access to category details through Entity Framework.
    /// Configured with foreign key relationship for efficient data loading.
    /// </summary>
    [ForeignKey(nameof(CategoryId))]
    public CategoryEntity? Category { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when this feedback was created.
    /// Automatically set to current UTC time when entity is instantiated.
    /// Uses datetime2 SQL Server type for improved precision and range.
    /// Essential for chronological analysis and audit trails.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets whether this feedback was submitted anonymously.
    /// When true, user identification fields (UserId, UserName) should be null.
    /// Supports privacy-conscious feedback collection while maintaining data integrity.
    /// </summary>
    public bool IsAnonymous { get; set; }
}
