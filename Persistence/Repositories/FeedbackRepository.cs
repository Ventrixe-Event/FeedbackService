/**
 * FeedbackService Feedback Repository Implementation - Entity-Specific Data Access
 *
 * Purpose: Concrete repository implementation for feedback entity data operations
 * Features:
 * - Inherits all common CRUD operations from BaseRepository
 * - Provides typed operations specifically for FeedbackEntity
 * - Maintains clean separation with entity-specific data access
 * - Ready for future feedback-specific method implementations
 *
 * Architecture: Part of the Persistence layer in clean architecture
 * - Extends BaseRepository<FeedbackEntity> for type-specific operations
 * - Implements IFeedbackRepository interface contract
 * - Uses dependency injection for DataContext access
 * - Provides foundation for future feedback-specific queries
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Interfaces;

namespace Persistence.Repositories;

/// <summary>
/// Repository implementation for feedback entity data access operations.
/// Extends the base repository to provide type-safe operations specifically for FeedbackEntity.
/// Inherits all standard CRUD operations while maintaining the foundation for future
/// feedback-specific methods such as event-based queries or rating aggregations.
/// Uses dependency injection for database context access.
/// </summary>
public class FeedbackRepository(DataContext context)
    : BaseRepository<FeedbackEntity>(context),
        IFeedbackRepository
{
    // Currently inherits all functionality from BaseRepository<FeedbackEntity>
    // Future feedback-specific methods can be implemented here:
    //
    // public async Task<RepositoryResult<IEnumerable<FeedbackEntity>>> GetByEventIdAsync(string eventId)
    // {
    //     return await GetAllAsync(); // Custom implementation would filter by EventId
    // }
    //
    // public async Task<RepositoryResult<double>> GetAverageRatingAsync(string eventId)
    // {
    //     // Custom implementation for rating calculations
    // }
}
