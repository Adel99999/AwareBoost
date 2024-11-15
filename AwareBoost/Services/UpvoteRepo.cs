using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;

namespace AwareBoost.Services
{
    public class UpvoteRepo : Repository<Upvote>, IUpvoteRepo
    {
        private readonly AppDbContext _db;
        public UpvoteRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
