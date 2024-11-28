using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;
using Microsoft.EntityFrameworkCore;

namespace AwareBoost.Services
{
    public class UpvoteRepo : Repository<Upvote>, IUpvoteRepo
    {
        private readonly AppDbContext _db;
        public UpvoteRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<int> CountUpvotesByAnswerIdAsync(Guid answerId)
        {
            return await _db.Upvote.CountAsync(a => a.AnswerId == answerId);
        }
    }
}
