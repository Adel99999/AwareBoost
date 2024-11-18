using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;
using Microsoft.EntityFrameworkCore;

namespace AwareBoost.Services
{
    public class QuestionsTagsRepo : Repository<QuestionsTags>, IQuestionsTagsRepo
    {
        private readonly AppDbContext _db;
        public QuestionsTagsRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task AddRangeAsync(IEnumerable<QuestionsTags> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            await _db.AddRangeAsync(entities);
            await _db.SaveChangesAsync(); // Save changes here
        }
    }
}
