using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;

namespace AwareBoost.Services
{
    public class FollowersRepo:Repository<Followers>,IFollowersRepo
    {
        private readonly AppDbContext _db;
        public FollowersRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
