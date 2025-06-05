/**
 * FeedbackService Repository Result Models - Data Access Result Pattern
 *
 * Purpose: Result pattern implementation for consistent repository-level error handling
 * Features:
 * - Base result class with success/error status for data operations
 * - Generic result class with typed return data from repositories
 * - Consistent error handling across all repository operations
 * - Clean separation of success and failure scenarios at data layer
 *
 * Architecture: Part of the Persistence layer in clean architecture
 * - Implements result pattern for repository error handling consistency
 * - Provides type-safe operation results at the data access level
 * - Eliminates exception-based error handling in favor of explicit results
 * - Enables functional programming patterns and better repository testability
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

namespace Persistence.Models;

/// <summary>
/// Base result class for repository operations providing success/failure status and error information.
/// Implements the result pattern to provide explicit error handling at the data access layer.
/// Used as a base for all repository operation results to ensure consistent error handling patterns.
/// Eliminates the need for exception handling in repository operations.
/// </summary>
public class RepositoryResult
{
    /// <summary>
    /// Gets or sets whether the repository operation completed successfully.
    /// True indicates successful data operation, false indicates a data access error occurred.
    /// Should be checked before proceeding with business logic or accessing result data.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the error message when the repository operation fails.
    /// Null when Success is true, contains detailed error information when Success is false.
    /// Provides specific error details for logging, debugging, and error reporting purposes.
    /// </summary>
    public string? Error { get; set; }
}

/// <summary>
/// Generic result class that extends the base repository result with typed return data.
/// Provides type-safe repository operation results while maintaining consistent error handling.
/// Used for repository operations that return data upon successful completion.
/// </summary>
/// <typeparam name="T">The type of data returned by the repository operation when successful</typeparam>
public class RepositoryResult<T> : RepositoryResult
{
    /// <summary>
    /// Gets or sets the result data when the repository operation completes successfully.
    /// Null when Success is false, contains the repository operation result when Success is true.
    /// Type is determined by the generic parameter T for compile-time type safety.
    /// </summary>
    public T? Result { get; set; }
}
