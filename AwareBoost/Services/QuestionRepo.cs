using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;
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


        public async Task UpdateAsync(Questions question)
        {
            _db.Questions.Update(question);
            await _db.SaveChangesAsync();
        }
    }
}
