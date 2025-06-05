/**
 * FeedbackService Application Interface - Business Logic Contract
 *
 * Purpose: Defines the contract for feedback management business logic operations
 * Features:
 * - Complete CRUD operations for feedback items
 * - Event-specific feedback retrieval and filtering
 * - Result pattern for consistent error handling
 * - Asynchronous operations for optimal performance
 *
 * Architecture: Part of the Application layer in clean architecture
 * - Abstracts business logic from presentation layer
 * - Enables dependency inversion and testability
 * - Supports result pattern for error handling
 * - Facilitates service layer implementation
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using Application.Models;
using Persistence.Entities;

namespace Application.Interfaces;

/// <summary>
/// Service interface for feedback management business logic operations.
/// Provides a contract for all feedback-related business operations including
/// creation, retrieval, and event-specific filtering. All operations use the
/// result pattern for consistent error handling and status reporting.
/// </summary>
public interface IFeedbackService
{
    /// <summary>
    /// Creates a new feedback item in the system.
    /// Processes the feedback creation request, validates business rules,
    /// and persists the feedback entity to the data store.
    /// </summary>
    /// <param name="request">The feedback creation request containing all necessary feedback data</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created feedback entity wrapped in a result object with success/error status.</returns>
    Task<FeedbackResult<FeedbackEntity>> CreateFeedbackAsync(CreateFeedbackRequest request);

    /// <summary>
    /// Retrieves all feedback items from the system.
    /// Returns a comprehensive list of feedback items converted to DTOs
    /// for presentation layer consumption.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of feedback DTOs wrapped in a result object with success/error status.</returns>
    Task<FeedbackResult<IEnumerable<Feedback>>> GetFeedbacksAsync();

    /// <summary>
    /// Retrieves a specific feedback item by its unique identifier.
    /// Converts the entity to a DTO for presentation layer consumption
    /// while preserving all relevant feedback information.
    /// </summary>
    /// <param name="feedbackId">The unique identifier of the feedback item to retrieve</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the feedback DTO if found, wrapped in a result object with success/error status.</returns>
    Task<FeedbackResult<Feedback>> GetFeedbackAsync(string feedbackId);

    /// <summary>
    /// Retrieves all feedback items associated with a specific event.
    /// Filters feedback by event ID and returns DTOs suitable for
    /// event-specific feedback analysis and reporting.
    /// </summary>
    /// <param name="eventId">The unique identifier of the event to retrieve feedback for</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of event-specific feedback DTOs wrapped in a result object with success/error status.</returns>
    Task<FeedbackResult<IEnumerable<Feedback>>> GetFeedbacksByEventAsync(string eventId);
}
