using AwareBoost.Models;

namespace AwareBoost.Repository
{
    public interface IUpvoteRepo:IRepository<Upvote>
    {
        Task<int> CountUpvotesByAnswerIdAsync(Guid answerId);
    }
}
