/**
 * FeedbackService Category Entity - Event Category Database Model
 *
 * Purpose: Entity Framework Core entity representing event categories in the database
 * Features:
 * - Simple category structure with ID, name, and description
 * - Reference data for event categorization
 * - Supports feedback segmentation and analysis by category
 * - Provides structured classification for event types
 *
 * Architecture: Part of the Persistence layer in clean architecture
 * - Maps to categories table in the database
 * - Referenced by FeedbackEntity for category association
 * - Serves as lookup/reference data for event classification
 * - Enables category-specific feedback analysis and reporting
 *
 * Database Schema:
 * - Primary key: Id (integer, auto-increment)
 * - Required fields: Name (category name)
 * - Optional fields: Description (category details)
 *
 * Examples:
 * - Music, Fashion, Food & Culinary, Technology, Art & Design
 * - Sports, Business, Entertainment, Health & Wellness
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

/// <summary>
/// Entity Framework Core entity representing event categories in the database.
/// Provides structured classification for events and enables category-specific feedback analysis.
/// Used as reference data to categorize events and segment feedback for reporting purposes.
/// Maintains a simple structure focused on essential categorization needs.
/// </summary>
public class CategoryEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for this category.
    /// Auto-incrementing integer serving as the primary key in the database.
    /// Used as foreign key reference in FeedbackEntity for category associations.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the event category.
    /// Required field providing the human-readable category identifier.
    /// Examples include "Music", "Fashion", "Food & Culinary", "Technology", etc.
    /// Used for display purposes and category-based filtering operations.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the detailed description of the event category.
    /// Optional field providing additional context and explanation for the category.
    /// Useful for administrative purposes and category management interfaces.
    /// Helps clarify category scope and intended event types.
    /// </summary>
    public string? Description { get; set; }
}
