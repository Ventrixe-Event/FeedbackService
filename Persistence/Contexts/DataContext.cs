/**
 * FeedbackService Database Context - Entity Framework Core Data Access
 *
 * Purpose: Entity Framework Core database context for feedback service data operations
 * Features:
 * - Database context configuration with dependency injection support
 * - DbSet configuration for feedback entities
 * - Clean and simple context focused on essential operations
 * - Support for Entity Framework Core migrations and design-time operations
 *
 * Architecture: Part of the Persistence layer in clean architecture
 * - Provides data access abstraction over the database
 * - Manages entity lifecycles and change tracking
 * - Supports dependency injection through constructor configuration
 * - Works with DesignTimeDbContextFactory for migration operations
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Contexts;

/// <summary>
/// Entity Framework Core database context for the Feedback Service.
/// Provides data access layer abstraction and entity configuration for feedback operations.
/// Configured through dependency injection with connection string from application settings.
/// Supports both runtime operations and design-time migrations through the factory pattern.
/// </summary>
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the feedback entities database set.
    /// Represents the Feedbacks table in the database with full CRUD operations.
    /// Provides queryable interface for feedback data access and manipulation.
    /// </summary>
    public DbSet<FeedbackEntity> Feedbacks { get; set; }
}
