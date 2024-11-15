using AwareBoost.Data;
using AwareBoost.Models;
using AwareBoost.Repository;
using System.Linq.Expressions;

namespace AwareBoost.Services
{
    public class UserBadgesRepo : Repository<UserBadges>, IUserBadgesRepo
    {
        private readonly AppDbContext _db;
        public UserBadgesRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
