using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AwareBoost.Services
{
    public class QuestionRepo : Repository<Questions>, IQuestionsRepo
    {
        private readonly AppDbContext _db;
        public QuestionRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Questions>> GetAllAsync(Expression<Func<Questions, bool>>? filter = null)
        {
            return await _db.Questions.Where(filter).Include(q => q.User).Include(q => q.Category).Include(q => q.Tags).AsNoTracking().ToListAsync();
        }
       

        public async Task UpdateAsync(Questions question)
        {
            _db.Questions.Update(question);
            await _db.SaveChangesAsync();
        }
    }
}
