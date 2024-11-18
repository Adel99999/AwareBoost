using AwareBoost.Models;

namespace AwareBoost.Repository
{
    public interface IAnswerRepo :IRepository<Answers>
    {
        Task UpdateAsync(Answers answer);
        Task<int> CountAnswersByQuestionIdAsync(Guid questionId);
        Task<List<Answers>> GetAnswersByQuestionIdAsync(Guid questionId);
    }
}
