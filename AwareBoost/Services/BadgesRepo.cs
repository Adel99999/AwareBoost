using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;

namespace AwareBoost.Services
{
    public class BadgesRepo : Repository<Badges>, IBadgesRepo
    {
        private readonly AppDbContext _db;
        public BadgesRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Badges badge)
        {
            _db.Badges.Update(badge);
            await _db.SaveChangesAsync();
        }
    }
}
