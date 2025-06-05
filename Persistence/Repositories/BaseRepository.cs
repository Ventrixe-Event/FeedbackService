/**
 * FeedbackService Base Repository Implementation - Generic Data Access Layer
 *
 * Purpose: Abstract base repository providing common Entity Framework Core data operations
 * Features:
 * - Generic CRUD operations for any entity type
 * - Expression-based querying with Entity Framework Core
 * - Result pattern error handling with comprehensive exception management
 * - DbContext and DbSet abstraction for consistent data access
 *
 * Architecture: Part of the Persistence layer in clean architecture
 * - Implements IBaseRepository<TEntity> interface for generic operations
 * - Uses Entity Framework Core for database interactions
 * - Provides base functionality for all entity-specific repositories
 * - Handles exceptions gracefully with result pattern responses
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Interfaces;
using Persistence.Models;

namespace Persistence.Repositories;

/// <summary>
/// Abstract base repository providing common Entity Framework Core data access operations.
/// Implements the IBaseRepository interface with generic CRUD functionality for any entity type.
/// Uses result pattern for consistent error handling and provides DbContext abstraction.
/// Serves as the foundation for all entity-specific repository implementations.
/// </summary>
/// <typeparam name="TEntity">The entity type this repository manages, must be a reference type</typeparam>
public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// The Entity Framework Core database context for data operations.
    /// Provides access to the database and manages entity lifecycle and change tracking.
    /// </summary>
    protected readonly DataContext _context;

    /// <summary>
    /// The Entity Framework Core DbSet for the specific entity type.
    /// Provides typed access to the entity collection and LINQ query capabilities.
    /// </summary>
    protected readonly DbSet<TEntity> _table;

    /// <summary>
    /// Initializes a new instance of the BaseRepository with the specified database context.
    /// Sets up the DbSet for the entity type and prepares for data operations.
    /// </summary>
    /// <param name="context">The Entity Framework Core database context for data access</param>
    public BaseRepository(DataContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>(); // Get the DbSet for the entity type
    }

    /// <summary>
    /// Retrieves all entities of the specified type from the database.
    /// Loads all records into memory and returns them as an enumerable collection.
    /// Uses async operations to avoid blocking the calling thread.
    /// </summary>
    /// <returns>A repository result containing all entities or error information</returns>
    public virtual async Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync()
    {
        try
        {
            // Execute async query to retrieve all entities
            var entities = await _table.ToListAsync();
            return new RepositoryResult<IEnumerable<TEntity>> { Success = true, Result = entities };
        }
        catch (Exception ex)
        {
            // Handle any database or Entity Framework errors
            return new RepositoryResult<IEnumerable<TEntity>>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    /// <summary>
    /// Retrieves a single entity matching the specified expression from the database.
    /// Returns the first entity that matches the criteria or null if no match is found.
    /// Uses async operations to avoid blocking the calling thread.
    /// </summary>
    /// <param name="expression">The expression defining the criteria to find the entity</param>
    /// <returns>A repository result containing the matching entity or error information</returns>
    public virtual async Task<RepositoryResult<TEntity?>> GetAsync(
        Expression<Func<TEntity, bool>> expression
    )
    {
        try
        {
            // Execute async query with expression-based filtering
            var entity = await _table.FirstOrDefaultAsync(expression);
            return new RepositoryResult<TEntity?>
            {
                Success = true,
                Result = entity ?? throw new Exception("Not found"), // Throw if entity is null
            };
        }
        catch (Exception ex)
        {
            // Handle query errors or "not found" exceptions
            return new RepositoryResult<TEntity?> { Success = false, Error = ex.Message };
        }
    }

    /// <summary>
    /// Adds a new entity to the database.
    /// Marks the entity for addition and persists changes to the database.
    /// Uses async operations to avoid blocking the calling thread.
    /// </summary>
    /// <param name="entity">The entity to add to the database</param>
    /// <returns>A repository result indicating success or failure with error details</returns>
    public virtual async Task<RepositoryResult> AddAsync(TEntity entity)
    {
        try
        {
            // Mark entity for addition in the change tracker
            _table.Add(entity);

            // Persist changes to the database
            await _context.SaveChangesAsync();
            return new RepositoryResult { Success = true };
        }
        catch (Exception ex)
        {
            // Handle database constraints, validation errors, or connection issues
            return new RepositoryResult { Success = false, Error = ex.Message };
        }
    }

    /// <summary>
    /// Updates an existing entity in the database.
    /// Marks the entity for modification and persists changes to the database.
    /// Uses async operations to avoid blocking the calling thread.
    /// </summary>
    /// <param name="entity">The entity with updated values to persist</param>
    /// <returns>A repository result indicating success or failure with error details</returns>
    public virtual async Task<RepositoryResult> UpdateAsync(TEntity entity)
    {
        try
        {
            // Mark entity for modification in the change tracker
            _table.Update(entity);

            // Persist changes to the database
            await _context.SaveChangesAsync();
            return new RepositoryResult { Success = true };
        }
        catch (Exception ex)
        {
            // Handle concurrency conflicts, validation errors, or database issues
            return new RepositoryResult { Success = false, Error = ex.Message };
        }
    }

    /// <summary>
    /// Deletes an entity from the database.
    /// Marks the entity for removal and persists changes to the database.
    /// Uses async operations to avoid blocking the calling thread.
    /// </summary>
    /// <param name="entity">The entity to delete from the database</param>
    /// <returns>A repository result indicating success or failure with error details</returns>
    public virtual async Task<RepositoryResult> DeleteAsync(TEntity entity)
    {
        try
        {
            // Mark entity for removal in the change tracker
            _table.Remove(entity);

            // Persist changes to the database
            await _context.SaveChangesAsync();
            return new RepositoryResult { Success = true };
        }
        catch (Exception ex)
        {
            // Handle referential integrity constraints or database issues
            return new RepositoryResult { Success = false, Error = ex.Message };
        }
    }

    /// <summary>
    /// Checks whether an entity matching the specified expression exists in the database.
    /// Uses efficient database query to check for existence without loading data.
    /// Useful for validation and duplicate prevention operations.
    /// </summary>
    /// <param name="expression">The expression defining the criteria to check for existing entities</param>
    /// <returns>A repository result indicating whether a matching entity exists</returns>
    public virtual async Task<RepositoryResult> AlreadyExistsAsync(
        Expression<Func<TEntity, bool>> expression
    )
    {
        // Execute efficient existence check without loading entity data
        var result = await _table.AnyAsync(expression);
        return result
            ? new RepositoryResult { Success = true } // Entity exists
            : new RepositoryResult { Success = false }; // Entity does not exist
    }
}
