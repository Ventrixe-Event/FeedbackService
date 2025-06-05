/**
 * FeedbackService Base Repository Interface - Generic Data Access Contract
 *
 * Purpose: Generic repository interface defining common data access operations
 * Features:
 * - Generic CRUD operations for any entity type
 * - Expression-based querying and existence checking
 * - Result pattern for consistent error handling
 * - Asynchronous operations for optimal performance
 *
 * Architecture: Part of the Persistence layer in clean architecture
 * - Abstracts common data access patterns across entities
 * - Provides type-safe generic interface for repository implementations
 * - Enables consistent error handling through RepositoryResult pattern
 * - Supports dependency inversion principle for testability
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using System.Linq.Expressions;
using Persistence.Models;

namespace Persistence.Interfaces;

/// <summary>
/// Generic repository interface providing common data access operations for any entity type.
/// Defines standard CRUD operations with expression-based querying and result pattern error handling.
/// Enables consistent data access patterns across different entity types while maintaining type safety.
/// All operations are asynchronous to support scalable, non-blocking data access.
/// </summary>
/// <typeparam name="TEntity">The entity type this repository manages, must be a reference type</typeparam>
public interface IBaseRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Adds a new entity to the data store.
    /// Persists the entity and handles any database constraints or validation errors.
    /// </summary>
    /// <param name="entity">The entity to add to the data store</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a repository result indicating success or failure with error details.</returns>
    Task<RepositoryResult> AddAsync(TEntity entity);

    /// <summary>
    /// Checks whether an entity matching the specified expression already exists in the data store.
    /// Useful for validation and duplicate prevention before adding new entities.
    /// </summary>
    /// <param name="expression">The expression defining the criteria to check for existing entities</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a repository result indicating whether a matching entity exists.</returns>
    Task<RepositoryResult> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Deletes an entity from the data store.
    /// Removes the entity and handles any referential integrity constraints.
    /// </summary>
    /// <param name="entity">The entity to delete from the data store</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a repository result indicating success or failure with error details.</returns>
    Task<RepositoryResult> DeleteAsync(TEntity entity);

    /// <summary>
    /// Retrieves all entities of the specified type from the data store.
    /// Returns a comprehensive collection of all entities for the given type.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a repository result with all entities or error details.</returns>
    Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync();

    /// <summary>
    /// Retrieves a single entity matching the specified expression from the data store.
    /// Returns null if no entity matches the criteria, or the first match if multiple entities satisfy the expression.
    /// </summary>
    /// <param name="expression">The expression defining the criteria to find the entity</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a repository result with the matching entity or null if not found.</returns>
    Task<RepositoryResult<TEntity?>> GetAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Updates an existing entity in the data store.
    /// Modifies the entity and handles any validation or constraint errors.
    /// </summary>
    /// <param name="entity">The entity with updated values to persist to the data store</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a repository result indicating success or failure with error details.</returns>
    Task<RepositoryResult> UpdateAsync(TEntity entity);
}
