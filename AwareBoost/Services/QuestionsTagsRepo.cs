using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;

namespace AwareBoost.Services
{
    public class QuestionsTagsRepo : Repository<QuestionsTags>, IQuestionsTagsRepo
    {
        private readonly AppDbContext _db;
        public QuestionsTagsRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
