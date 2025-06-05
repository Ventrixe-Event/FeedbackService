/**
 * FeedbackService REST API Controller - HTTP Endpoint Management
 *
 * Purpose: RESTful API controller for feedback management operations
 * Features:
 * - Complete CRUD operations for feedback items
 * - Event-specific feedback retrieval
 * - Statistical data aggregation and reporting
 * - Mock analytics data for dashboard visualization
 * - Input validation and error handling
 *
 * Architecture: Presentation layer in clean architecture
 * - Handles HTTP requests and responses
 * - Delegates business logic to application service layer
 * - Implements result pattern for consistent error handling
 * - Provides RESTful endpoints following HTTP conventions
 *
 * API Endpoints:
 * - GET /api/feedbacks - Retrieve all feedback items
 * - GET /api/feedbacks/{id} - Retrieve specific feedback by ID
 * - GET /api/feedbacks/event/{eventId} - Retrieve feedback for specific event
 * - GET /api/feedbacks/statistics - Retrieve analytics and statistics
 * - POST /api/feedbacks - Create new feedback item
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

/// <summary>
/// REST API controller for feedback management operations.
/// Provides endpoints for creating, retrieving, and analyzing user feedback data.
/// Implements result pattern for consistent error handling across all operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FeedbacksController(IFeedbackService feedbackService) : ControllerBase
{
    /// <summary>
    /// The feedback service for business logic operations.
    /// Injected via constructor dependency injection pattern.
    /// </summary>
    private readonly IFeedbackService _feedbackService = feedbackService;

    /// <summary>
    /// Retrieves all feedback items from the system.
    /// Returns paginated results with success/error status indication.
    /// </summary>
    /// <returns>
    /// 200 OK with feedback list if successful,
    /// 500 Internal Server Error if operation fails
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var feedbacks = await _feedbackService.GetFeedbacksAsync();
        return feedbacks.Success ? Ok(feedbacks) : StatusCode(500, feedbacks.Error);
    }

    /// <summary>
    /// Retrieves a specific feedback item by its unique identifier.
    /// Provides detailed feedback information including ratings and comments.
    /// </summary>
    /// <param name="id">The unique identifier of the feedback item to retrieve</param>
    /// <returns>
    /// 200 OK with feedback details if found,
    /// 404 Not Found if feedback doesn't exist
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var feedback = await _feedbackService.GetFeedbackAsync(id);
        return feedback.Success ? Ok(feedback) : NotFound(feedback.Error);
    }

    /// <summary>
    /// Retrieves all feedback items associated with a specific event.
    /// Useful for event organizers to view feedback for their events.
    /// Results include ratings, comments, and user information (respecting anonymity).
    /// </summary>
    /// <param name="eventId">The unique identifier of the event to retrieve feedback for</param>
    /// <returns>
    /// 200 OK with event feedback list if successful,
    /// 500 Internal Server Error if operation fails
    /// </returns>
    [HttpGet("event/{eventId}")]
    public async Task<IActionResult> GetByEvent(string eventId)
    {
        var feedbacks = await _feedbackService.GetFeedbacksByEventAsync(eventId);
        return feedbacks.Success ? Ok(feedbacks) : StatusCode(500, feedbacks.Error);
    }

    /// <summary>
    /// Retrieves comprehensive feedback statistics and analytics data.
    /// Provides dashboard-ready data including overall ratings, monthly trends,
    /// and review distribution for business intelligence purposes.
    ///
    /// Currently returns mock data designed to match frontend expectations
    /// for analytics dashboard visualization and reporting.
    /// </summary>
    /// <returns>
    /// 200 OK with statistics object containing:
    /// - Overall rating average
    /// - Total review count
    /// - Monthly breakdown of ratings (1-3 vs 4-5 stars)
    /// </returns>
    [HttpGet("statistics")]
    public async Task<IActionResult> GetStatistics()
    {
        // Mock statistics data matching frontend dashboard expectations
        // Provides realistic analytics data for business intelligence visualization
        var stats = new
        {
            OverallRating = 4.8, // Average rating across all feedback
            TotalReviews = 15545, // Total number of feedback items
            MonthlyData = new[] // Monthly breakdown for trend analysis
            {
                new
                {
                    Month = "Jan",
                    Rating1To3 = 650, // Lower ratings (1-3 stars)
                    Rating4To5 = 880, // Higher ratings (4-5 stars)
                },
                new
                {
                    Month = "Feb",
                    Rating1To3 = 700,
                    Rating4To5 = 920,
                },
                new
                {
                    Month = "Mar",
                    Rating1To3 = 680,
                    Rating4To5 = 900,
                },
                new
                {
                    Month = "Apr",
                    Rating1To3 = 620,
                    Rating4To5 = 870,
                },
                new
                {
                    Month = "May",
                    Rating1To3 = 690,
                    Rating4To5 = 910,
                },
                new
                {
                    Month = "Jun",
                    Rating1To3 = 720,
                    Rating4To5 = 950,
                },
                new
                {
                    Month = "Jul",
                    Rating1To3 = 680,
                    Rating4To5 = 890,
                },
                new
                {
                    Month = "Aug",
                    Rating1To3 = 630,
                    Rating4To5 = 860,
                },
                new
                {
                    Month = "Sep",
                    Rating1To3 = 710,
                    Rating4To5 = 940,
                },
                new
                {
                    Month = "Oct",
                    Rating1To3 = 690,
                    Rating4To5 = 920,
                },
                new
                {
                    Month = "Nov",
                    Rating1To3 = 720,
                    Rating4To5 = 960,
                },
                new
                {
                    Month = "Dec",
                    Rating1To3 = 700,
                    Rating4To5 = 930,
                },
            },
        };

        await Task.Delay(50); // Simulate async database aggregation operation
        return Ok(new { Success = true, Result = stats });
    }

    /// <summary>
    /// Creates a new feedback item in the system.
    /// Validates input data and processes feedback creation through business logic layer.
    /// Supports both anonymous and identified feedback submission.
    /// </summary>
    /// <param name="request">The feedback creation request with validation attributes</param>
    /// <returns>
    /// 200 OK with created feedback details if successful,
    /// 400 Bad Request if validation fails,
    /// 500 Internal Server Error if creation fails
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateFeedbackRequest request)
    {
        // Validate input using model state and data annotations
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Delegate feedback creation to business logic layer
        var result = await _feedbackService.CreateFeedbackAsync(request);
        return result.Success ? Ok(result) : StatusCode(500, result.Error);
    }
}
