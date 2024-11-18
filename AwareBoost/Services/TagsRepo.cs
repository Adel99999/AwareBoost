using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;
using Microsoft.EntityFrameworkCore;

namespace AwareBoost.Services
{
    public class TagsRepo : Repository<Tags>, ITagsRepo
    {
        private readonly AppDbContext _db;
        public TagsRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Tags tag)
        {
            _db.Tags.Update(tag);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Tags>> GetTagsByNamesAsync(List<string> tagNames)
        {
            return await _db.Tags
                .Where(t => tagNames.Contains(t.TagName))
                .ToListAsync();
        }

    }
}
