using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;

namespace AwareBoost.Services
{
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        private readonly AppDbContext _db;
        public CategoryRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
