using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;

namespace AwareBoost.Services
{
    public class CommentsRepo:Repository<Comments>,ICommentsRepo
    {
        private readonly AppDbContext _db;
        public CommentsRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(Comments comment)
        {
            _db.Comments.Update(comment);
            await _db.SaveChangesAsync();
        }
    }
}
