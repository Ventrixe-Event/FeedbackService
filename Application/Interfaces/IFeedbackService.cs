using Application.Models;
using Persistence.Entities;

namespace Application.Interfaces;

public interface IFeedbackService
{
    Task<FeedbackResult<FeedbackEntity>> CreateFeedbackAsync(CreateFeedbackRequest request);
    Task<FeedbackResult<IEnumerable<Feedback>>> GetFeedbacksAsync();
    Task<FeedbackResult<Feedback>> GetFeedbackAsync(string feedbackId);
    Task<FeedbackResult<IEnumerable<Feedback>>> GetFeedbacksByEventAsync(string eventId);
}
