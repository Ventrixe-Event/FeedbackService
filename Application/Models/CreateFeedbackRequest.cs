/**
 * FeedbackService Create Feedback Request - Input Validation Model
 *
 * Purpose: Request model for creating new feedback items with comprehensive validation
 * Features:
 * - Required field validation for essential feedback data
 * - Rating validation with 1-5 scale constraints
 * - Support for detailed category-specific ratings
 * - Anonymous feedback submission support
 * - Event and category association tracking
 *
 * Architecture: Part of the Application layer in clean architecture
 * - Encapsulates input validation and business rules
 * - Provides data transfer object for feedback creation
 * - Supports comprehensive event feedback analysis
 * - Includes both overall and detailed rating mechanisms
 *
 * Rating Categories:
 * - Overall rating (required): General satisfaction score
 * - Venue rating: Facility and location quality
 * - Event organization: Planning and execution quality
 * - Staff support: Service and assistance quality
 * - Entertainment quality: Content and performance quality
 * - Food and beverages: Catering and refreshment quality
 * - Value for money: Cost-benefit perception
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using System.ComponentModel.DataAnnotations;

namespace Application.Models;

/// <summary>
/// Request model for creating new feedback items in the system.
/// Includes comprehensive validation rules and supports both anonymous and identified feedback.
/// Provides detailed rating categories for thorough event evaluation and analysis.
/// All rating fields use a 1-5 scale where 1 represents poor quality and 5 represents excellent quality.
/// </summary>
public class CreateFeedbackRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the event this feedback relates to.
    /// Required field that links the feedback to a specific event for analysis and reporting.
    /// Must be a valid event ID that exists in the system.
    /// </summary>
    [Required]
    public string EventId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the human-readable name of the event this feedback relates to.
    /// Optional field that provides context and improves user experience.
    /// Automatically populated when available to avoid additional lookups.
    /// </summary>
    public string? EventName { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user submitting this feedback.
    /// Optional field that should be null when feedback is submitted anonymously.
    /// Used for user-specific feedback tracking and follow-up communications.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user submitting this feedback.
    /// Optional field that should be null when feedback is submitted anonymously.
    /// Provides human-readable attribution for non-anonymous feedback.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the textual content of the feedback.
    /// Optional field allowing users to provide detailed comments, suggestions, and qualitative insights.
    /// Complements numerical ratings with rich contextual information.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets the overall rating for the event experience.
    /// Required field using a 1-5 scale validation where 1 is poor and 5 is excellent.
    /// Represents the user's general satisfaction and primary feedback metric.
    /// </summary>
    [Range(1, 5)]
    public int Rating { get; set; }

    /// <summary>
    /// Gets or sets the rating for the event venue and facilities.
    /// Optional detailed rating using a 1-5 scale for venue quality assessment.
    /// Covers aspects like location, accessibility, cleanliness, and facility adequacy.
    /// </summary>
    [Range(1, 5)]
    public int? VenueRating { get; set; }

    /// <summary>
    /// Gets or sets the rating for event organization and planning quality.
    /// Optional detailed rating using a 1-5 scale for organizational assessment.
    /// Covers aspects like scheduling, communication, logistics, and overall coordination.
    /// </summary>
    [Range(1, 5)]
    public int? EventOrganizationRating { get; set; }

    /// <summary>
    /// Gets or sets the rating for staff support and customer service quality.
    /// Optional detailed rating using a 1-5 scale for service assessment.
    /// Covers aspects like helpfulness, responsiveness, professionalism, and assistance quality.
    /// </summary>
    [Range(1, 5)]
    public int? StaffSupportRating { get; set; }

    /// <summary>
    /// Gets or sets the rating for entertainment and content quality.
    /// Optional detailed rating using a 1-5 scale for entertainment assessment.
    /// Covers aspects like performance quality, content relevance, engagement, and overall entertainment value.
    /// </summary>
    [Range(1, 5)]
    public int? EntertainmentQualityRating { get; set; }

    /// <summary>
    /// Gets or sets the rating for food and beverage quality and service.
    /// Optional detailed rating using a 1-5 scale for catering assessment.
    /// Covers aspects like food quality, variety, presentation, service, and value.
    /// </summary>
    [Range(1, 5)]
    public int? FoodAndBeveragesRating { get; set; }

    /// <summary>
    /// Gets or sets the rating for perceived value for money.
    /// Optional detailed rating using a 1-5 scale for cost-benefit assessment.
    /// Covers the relationship between event cost and delivered value/experience.
    /// </summary>
    [Range(1, 5)]
    public int? ValueForMoneyRating { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the event category.
    /// Optional field linking feedback to event categories for segmented analysis.
    /// Enables category-specific feedback aggregation and comparative reporting.
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the human-readable name of the event category.
    /// Optional field providing category context for feedback classification.
    /// Examples include "Music", "Food & Culinary", "Technology", "Art & Design", etc.
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// Gets or sets whether this feedback should be submitted anonymously.
    /// When true, user identification fields (UserId, UserName) should be ignored or nullified.
    /// Supports privacy-conscious feedback while maintaining data collection capabilities.
    /// </summary>
    public bool IsAnonymous { get; set; }
}
