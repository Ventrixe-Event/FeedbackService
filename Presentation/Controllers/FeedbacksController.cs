using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbacksController(IFeedbackService feedbackService) : ControllerBase
{
    private readonly IFeedbackService _feedbackService = feedbackService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var feedbacks = await _feedbackService.GetFeedbacksAsync();
        return feedbacks.Success ? Ok(feedbacks) : StatusCode(500, feedbacks.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var feedback = await _feedbackService.GetFeedbackAsync(id);
        return feedback.Success ? Ok(feedback) : NotFound(feedback.Error);
    }

    [HttpGet("event/{eventId}")]
    public async Task<IActionResult> GetByEvent(string eventId)
    {
        var feedbacks = await _feedbackService.GetFeedbacksByEventAsync(eventId);
        return feedbacks.Success ? Ok(feedbacks) : StatusCode(500, feedbacks.Error);
    }

    [HttpGet("statistics")]
    public async Task<IActionResult> GetStatistics()
    {
        // Mock statistics data matching frontend expectations
        var stats = new
        {
            OverallRating = 4.8,
            TotalReviews = 15545,
            MonthlyData = new[]
            {
                new
                {
                    Month = "Jan",
                    Rating1To3 = 650,
                    Rating4To5 = 880,
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

        await Task.Delay(50); // Simulate async operation
        return Ok(new { Success = true, Result = stats });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeedbackRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _feedbackService.CreateFeedbackAsync(request);
        return result.Success ? Ok(result) : StatusCode(500, result.Error);
    }
}
