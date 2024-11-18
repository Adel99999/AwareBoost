using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;
using Microsoft.EntityFrameworkCore;

namespace AwareBoost.Services
{
    public class AnswerRepo : Repository<Answers>, IAnswerRepo
    {
        private readonly AppDbContext _db;
        public AnswerRepo(AppDbContext db):base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Answers answer)
        {
            _db.Answers.Update(answer);
            await _db.SaveChangesAsync();
        }
        public async Task<int> CountAnswersByQuestionIdAsync(Guid questionId)
        {
            // Count answers associated with a specific question
            return await _db.Answers.CountAsync(a => a.QuestionId == questionId);
        }

        public async Task<List<Answers>> GetAnswersByQuestionIdAsync(Guid questionId)
        {
            return await _db.Answers
                .Where(a => a.QuestionId == questionId)
                .Include(a => a.User) // Include user details if needed
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
