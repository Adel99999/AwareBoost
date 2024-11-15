using System.Linq.Expressions;

namespace AwareBoost.Repository
{
    public interface IRepository<T> where T : class
    {
        
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);

        Task<T?> GetAsync(Expression<Func<T, bool>> filter);


        Task AddAsync(T entity);

        
        Task RemoveAsync(T entity);

        
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
