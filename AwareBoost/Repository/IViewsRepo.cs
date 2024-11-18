using AwareBoost.Models;

namespace AwareBoost.Repository
{
    public interface IViewsRepo:IRepository<Views>
    {
        Task<int> CountViewsByQuestionIdAsync(Guid questionId);

    }
}
