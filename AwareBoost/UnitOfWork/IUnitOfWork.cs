using AwareBoost.Repository;

namespace AwareBoost.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAnswerRepo AnswerRepo { get; }
        IBadgesRepo BadgesRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        ICommentsRepo CommentsRepo { get; }
        IFollowersRepo FollowersRepo { get; }
        IQuestionsRepo QuestionsRepo { get; }
        IQuestionsTagsRepo QuestionsTagsRepo { get; }
        ITagsRepo TagsRepo { get; }
        IUpvoteRepo UpvoteRepo { get; }
        IUserBadgesRepo UserBadgesRepo { get; }
        IViewsRepo ViewsRepo { get; }
    }
}
