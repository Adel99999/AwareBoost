using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;

namespace AwareBoost.Services
{
    public class ViewsRepo : Repository<Views>, IViewsRepo
    {
        private readonly AppDbContext _db;
        public ViewsRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
