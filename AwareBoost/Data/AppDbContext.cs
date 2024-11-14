using AwareBoost.Data.Config;
using AwareBoost.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AwareBoost.Data
{
    public class AppDbContext : IdentityDbContext<AppUsers>
    {
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Badges> Badges { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Followers> Followers { get; set; }
        public DbSet<QuestionsTags> QuestionsTags { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Upvote> Upvote { get; set; }
        public DbSet<UserBadges> UserBadges { get; set; }
        public DbSet<Views> Views { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AnswersConfiguration).Assembly);
        }
    }

}
