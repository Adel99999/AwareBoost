using AwareBoost.Models;

namespace AwareBoost.Repository
{
    public interface ICommentsRepo : IRepository<Comments>
    {
        Task UpdateAsync(Comments comment);

    }
}
