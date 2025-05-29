using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class FeedbackRepository(DataContext context)
    : BaseRepository<FeedbackEntity>(context),
        IFeedbackRepository { }
