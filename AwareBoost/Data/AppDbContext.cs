using AwareBoost.Data.Config;
using AwareBoost.Models;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Upvote> Upvote { get; set; }
        public DbSet<UserBadges> UserBadges { get; set; }
        public DbSet<Views> Views { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AnswersConfiguration).Assembly);

            //seeding data for identity role
            var UserId = "8f2da2d1-415e-4d5f-b997-846a32c990ae";
            var AdminId = "2d15548c-31b1-4a36-a231-16de6a482862";
            var SpecialUserId = "A3B6BDFD-04AF-4809-B9A3-009589CCD2B6";

            var obj = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=UserId,
                    ConcurrencyStamp=UserId,
                    Name="User",
                    NormalizedName="User".ToUpper()
                },
                new IdentityRole
                {
                    Id=AdminId,
                    ConcurrencyStamp=AdminId,
                    Name="Admin",
                    NormalizedName="admin".ToUpper()
                },
                new IdentityRole
                {
                    Id=SpecialUserId,
                    ConcurrencyStamp=SpecialUserId,
                    Name="SpecialUser",
                    NormalizedName="SpecialUser".ToUpper()
                }

            };
           builder.Entity<IdentityRole>().HasData(obj);
        }
    }

}
