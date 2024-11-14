using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class FollowersConfiguration : IEntityTypeConfiguration<Followers>
    {
        public void Configure(EntityTypeBuilder<Followers> builder)
        {
            // Define Primary Key
            builder.HasKey(f => f.Id);

            // Define the relationship between Followers and SpecialUser
            builder.HasOne(f => f.SpecialUser)
                   .WithMany(u => u.Followers)  // The SpecialUser can have many followers
                   .HasForeignKey(f => f.SpecialUserId)
                   .OnDelete(DeleteBehavior.NoAction);  // When a SpecialUser is deleted, their followers are also deleted (can adjust as needed)

            // Define the relationship between Followers and FollowerUser
            builder.HasOne(f => f.FollowerUser)
                   .WithMany(u => u.Followings)  // The FollowerUser can have many followings
                   .HasForeignKey(f => f.FollowerId)
                   .OnDelete(DeleteBehavior.NoAction);  // When a FollowerUser is deleted, their followings are also deleted (can adjust as needed)
        }
    }
}
