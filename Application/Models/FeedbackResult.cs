/**
 * FeedbackService Result Models - Result Pattern Implementation
 *
 * Purpose: Result pattern implementation for consistent error handling and status reporting
 * Features:
 * - Base result class with success/error status
 * - Generic result class with typed return data
 * - Consistent error handling across all operations
 * - Clean separation of success and failure scenarios
 *
 * Architecture: Part of the Application layer in clean architecture
 * - Implements result pattern for error handling consistency
 * - Provides type-safe operation results
 * - Eliminates exception-based error handling in favor of explicit results
 * - Enables functional programming patterns and better testability
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

namespace Application.Models;

/// <summary>
/// Base result class providing success/failure status and error information.
/// Implements the result pattern to provide explicit error handling without exceptions.
/// Used as a base for all operation results to ensure consistent error handling across the application.
/// </summary>
public class FeedbackResult
{
    /// <summary>
    /// Gets or sets whether the operation completed successfully.
    /// True indicates successful completion, false indicates an error occurred.
    /// Should be checked before accessing any result data or performing subsequent operations.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the error message when the operation fails.
    /// Null when Success is true, contains descriptive error information when Success is false.
    /// Provides human-readable error details for logging, debugging, and user communication.
    /// </summary>
    public string? Error { get; set; }
}

/// <summary>
/// Generic result class that extends the base result with typed return data.
/// Provides type-safe operation results while maintaining consistent error handling.
/// Used for operations that return data upon successful completion.
/// </summary>
/// <typeparam name="T">The type of data returned by the operation when successful</typeparam>
public class FeedbackResult<T> : FeedbackResult
{
    /// <summary>
    /// Gets or sets the result data when the operation completes successfully.
    /// Null when Success is false, contains the operation result when Success is true.
    /// Type is determined by the generic parameter T for compile-time type safety.
    /// </summary>
    public T? Result { get; set; }
}
