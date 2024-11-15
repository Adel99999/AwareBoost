using AwareBoost.Models;

namespace AwareBoost.Repository
{
    public interface IAnswerRepo :IRepository<Answers>
    {
        Task UpdateAsync(Answers answer);
    }
}
