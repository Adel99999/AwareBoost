using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;

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
    }
}
