using AwareBoost.Models;

namespace AwareBoost.Repository
{
    public interface ITagsRepo : IRepository<Tags>
    {
        Task UpdateAsync(Tags tag);
        Task<List<Tags>> GetTagsByNamesAsync(List<string> tagNames);
    }
}
