using AwareBoost.Models;

namespace AwareBoost.Repository
{
    public interface IBadgesRepo:IRepository<Badges>
    {
        Task UpdateAsync(Badges Badge);

    }
}
