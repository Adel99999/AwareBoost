using AwareBoost.Models;
using System.Linq.Expressions;

namespace AwareBoost.Repository
{
    public interface IQuestionsRepo : IRepository<Questions>
    {
        Task UpdateAsync(Questions question);
        Task<IEnumerable<Questions>> GetAllAsync(Expression<Func<Questions, bool>>? filter = null);
    }
}
