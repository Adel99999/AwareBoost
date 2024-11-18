using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;
using Microsoft.EntityFrameworkCore;

namespace AwareBoost.Services
{
    public class ViewsRepo : Repository<Views>, IViewsRepo
    {
        private readonly AppDbContext _db;
        public ViewsRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<int> CountViewsByQuestionIdAsync(Guid questionId)
        {
            return await _db.Views.CountAsync(a => a.QuesitonId== questionId);
        }
    }
}
