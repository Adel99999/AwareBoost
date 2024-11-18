using AwareBoost.Models;

namespace AwareBoost.Repository
{
    public interface IQuestionsTagsRepo:IRepository<QuestionsTags>
    {
        Task AddRangeAsync(IEnumerable<QuestionsTags> entities);
    }
}
