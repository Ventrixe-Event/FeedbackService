using Application.Interfaces;
using Application.Models;
using Persistence.Entities;
using Persistence.Interfaces;

namespace Application.Services;

public class FeedbackService(IFeedbackRepository feedbackRepository) : IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository = feedbackRepository;

    // Mock data for development/demo purposes
    private readonly List<Feedback> _mockFeedbacks = new()
    {
        new Feedback
        {
            Id = "1",
            EventId = "evt-1",
            EventName = "Echo Beats Festival",
            UserId = "user-1",
            UserName = "Jackson Moore",
            Content =
                "An absolutely amazing festival! The lineup of artists was incredible, and the sound quality was impeccable. The energy from the crowd made it a night to remember.",
            Rating = 5,
            CategoryId = 1,
            CategoryName = "Music",
            CreatedAt = new DateTime(2029, 4, 22),
            IsAnonymous = false,
        },
        new Feedback
        {
            Id = "2",
            EventId = "evt-2",
            EventName = "Runway Revolution 2029",
            UserId = "user-2",
            UserName = "Alicia Smithson",
            Content =
                "Beautiful designs and a well-organized event overall. The models and lighting were captivating, but the seating arrangements could have been planned better for the audience.",
            Rating = 4,
            CategoryId = 2,
            CategoryName = "Fashion",
            CreatedAt = new DateTime(2029, 5, 2),
            IsAnonymous = false,
        },
        new Feedback
        {
            Id = "3",
            EventId = "evt-3",
            EventName = "Symphony Under the Stars",
            UserId = "user-3",
            UserName = "Patrick Cooper",
            Content =
                "The music under the open sky was breathtaking. The orchestra was phenomenal, and the ambiance made it feel like a dream. Everything was organized beautifully.",
            Rating = 5,
            CategoryId = 1,
            CategoryName = "Music",
            CreatedAt = new DateTime(2029, 4, 20),
            IsAnonymous = false,
        },
        new Feedback
        {
            Id = "4",
            EventId = "evt-4",
            EventName = "Culinary Delights Festival",
            UserId = "user-4",
            UserName = "Clara Simmons",
            Content =
                "The variety of cuisines and food stalls was fantastic! The flavors were outstanding, though some popular stalls ran out of food too early in the event.",
            Rating = 4,
            CategoryId = 3,
            CategoryName = "Food & Culinary",
            CreatedAt = new DateTime(2029, 5, 25),
            IsAnonymous = false,
        },
        new Feedback
        {
            Id = "5",
            EventId = "evt-5",
            EventName = "Artistry Unveiled Expo",
            UserId = "user-5",
            UserName = "Natalie Johnson",
            Content =
                "The expo was a treat for art lovers! The installations were awe-inspiring, and the chance to meet artists was a highlight of the event for me.",
            Rating = 5,
            CategoryId = 4,
            CategoryName = "Art & Design",
            CreatedAt = new DateTime(2029, 5, 15),
            IsAnonymous = false,
        },
        new Feedback
        {
            Id = "6",
            EventId = "evt-6",
            EventName = "Tech Future Expo",
            UserId = "user-6",
            UserName = "Henry Carter",
            Content =
                "A fantastic platform for tech enthusiasts to explore the latest innovations. More hands-on workshops would have made the event even better, but it was still very informative.",
            Rating = 4,
            CategoryId = 5,
            CategoryName = "Technology",
            CreatedAt = new DateTime(2029, 6, 1),
            IsAnonymous = false,
        },
        new Feedback
        {
            Id = "7",
            EventId = "evt-7",
            EventName = "Garden Party Gala",
            UserId = "user-7",
            UserName = "Emily Watson",
            Content =
                "A beautiful outdoor event with lovely decorations and great networking opportunities. The weather was perfect and the atmosphere was delightful.",
            Rating = 5,
            CategoryId = 6,
            CategoryName = "Social",
            CreatedAt = new DateTime(2029, 5, 30),
            IsAnonymous = false,
        },
        new Feedback
        {
            Id = "8",
            EventId = "evt-8",
            EventName = "Sports Championship Finals",
            UserId = "user-8",
            UserName = "Michael Rodriguez",
            Content =
                "Incredible energy throughout the entire event! The competition was fierce and the crowd support was amazing. Great organization by the event team.",
            Rating = 5,
            CategoryId = 7,
            CategoryName = "Sports",
            CreatedAt = new DateTime(2029, 6, 10),
            IsAnonymous = false,
        },
        new Feedback
        {
            Id = "9",
            EventId = "evt-9",
            EventName = "Business Innovation Summit",
            UserId = "user-9",
            UserName = "Sarah Chen",
            Content =
                "Very informative sessions with industry leaders. The networking opportunities were valuable, though some presentations could have been more interactive.",
            Rating = 4,
            CategoryId = 8,
            CategoryName = "Business",
            CreatedAt = new DateTime(2029, 5, 18),
            IsAnonymous = false,
        },
        new Feedback
        {
            Id = "10",
            EventId = "evt-10",
            EventName = "Comedy Night Special",
            UserId = "user-10",
            UserName = "David Wilson",
            Content =
                "Hilarious performances from start to finish! All the comedians were fantastic and the venue had a great intimate atmosphere. Definitely recommend!",
            Rating = 5,
            CategoryId = 9,
            CategoryName = "Entertainment",
            CreatedAt = new DateTime(2029, 6, 5),
            IsAnonymous = false,
        },
    };

    public async Task<FeedbackResult<FeedbackEntity>> CreateFeedbackAsync(
        CreateFeedbackRequest request
    )
    {
        try
        {
            var feedbackEntity = new FeedbackEntity
            {
                EventId = request.EventId,
                UserId = request.UserId,
                Content = request.Content,
                Rating = request.Rating,
                IsAnonymous = request.IsAnonymous,
                CreatedAt = DateTime.UtcNow,
            };

            var result = await _feedbackRepository.AddAsync(feedbackEntity);
            return result.Success
                ? new FeedbackResult<FeedbackEntity> { Success = true, Result = feedbackEntity }
                : new FeedbackResult<FeedbackEntity> { Success = false, Error = result.Error };
        }
        catch (Exception ex)
        {
            return new FeedbackResult<FeedbackEntity> { Success = false, Error = ex.Message };
        }
    }

    public async Task<FeedbackResult<IEnumerable<Feedback>>> GetFeedbacksAsync()
    {
        // Return mock data for now
        await Task.Delay(100); // Simulate async operation

        return new FeedbackResult<IEnumerable<Feedback>>
        {
            Success = true,
            Result = _mockFeedbacks,
            Error = null,
        };
    }

    public async Task<FeedbackResult<Feedback>> GetFeedbackAsync(string feedbackId)
    {
        // Return mock data for now
        await Task.Delay(50); // Simulate async operation

        var feedback = _mockFeedbacks.FirstOrDefault(f => f.Id == feedbackId);

        if (feedback != null)
        {
            return new FeedbackResult<Feedback> { Success = true, Result = feedback };
        }

        return new FeedbackResult<Feedback> { Success = false, Error = "Feedback not found" };
    }

    public async Task<FeedbackResult<IEnumerable<Feedback>>> GetFeedbacksByEventAsync(
        string eventId
    )
    {
        // Return mock data for now
        await Task.Delay(100); // Simulate async operation

        var feedbacks = _mockFeedbacks.Where(f => f.EventId == eventId);

        return new FeedbackResult<IEnumerable<Feedback>>
        {
            Success = true,
            Result = feedbacks,
            Error = null,
        };
    }
}
