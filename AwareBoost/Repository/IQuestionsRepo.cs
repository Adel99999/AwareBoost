using AwareBoost.Models;

namespace AwareBoost.Repository
{
    public interface IQuestionsRepo : IRepository<Questions>
    {
        Task UpdateAsync(Questions question);

    }
}
