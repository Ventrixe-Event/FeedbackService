/**
 * FeedbackService Feedback Repository Interface - Specific Data Access Contract
 *
 * Purpose: Feedback-specific repository interface extending base repository functionality
 * Features:
 * - Inherits all common CRUD operations from IBaseRepository
 * - Typed specifically for FeedbackEntity operations
 * - Provides feedback-specific data access contract
 * - Enables dependency injection and testing with feedback entities
 *
 * Architecture: Part of the Persistence layer in clean architecture
 * - Extends IBaseRepository<FeedbackEntity> for type-specific operations
 * - Maintains separation of concerns with entity-specific interfaces
 * - Supports dependency inversion for feedback data access
 * - Enables future feedback-specific methods if needed
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using Persistence.Entities;

namespace Persistence.Interfaces;

/// <summary>
/// Repository interface for feedback entity data access operations.
/// Extends the base repository interface to provide typed operations specifically for FeedbackEntity.
/// Inherits all standard CRUD operations while maintaining type safety for feedback-specific data access.
/// Can be extended with feedback-specific methods if specialized operations are needed in the future.
/// </summary>
public interface IFeedbackRepository : IBaseRepository<FeedbackEntity>
{
    // Currently inherits all operations from IBaseRepository<FeedbackEntity>
    // Additional feedback-specific methods can be added here as needed:
    // - Task<RepositoryResult<IEnumerable<FeedbackEntity>>> GetByEventIdAsync(string eventId);
    // - Task<RepositoryResult<IEnumerable<FeedbackEntity>>> GetByCategoryAsync(int categoryId);
    // - Task<RepositoryResult<double>> GetAverageRatingAsync(string eventId);
}
