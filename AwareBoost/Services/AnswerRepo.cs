using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;

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
    }
}
