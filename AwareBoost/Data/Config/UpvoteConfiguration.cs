using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class UpvoteConfiguration : IEntityTypeConfiguration<Upvote>
    {
        public void Configure(EntityTypeBuilder<Upvote> builder)
        {
            // Primary Key configuration
            builder.HasKey(u => u.Id);

            // Relationship configuration for AppUser and Upvote
            builder.HasOne(u => u.User) // Each Upvote is by one AppUser
                   .WithMany(a => a.Upvotes) // An AppUser can have many Upvotes
                   .HasForeignKey(u => u.AppUserId) // Foreign key in Upvote table
                   .OnDelete(DeleteBehavior.Cascade); // If an AppUser is deleted, their Upvotes will be deleted

            // Relationship configuration for Answer and Upvote
            builder.HasOne(u => u.Answer) // Each Upvote is for one Answer
                   .WithMany(a => a.Upvotes) // An Answer can have many Upvotes
                   .HasForeignKey(u => u.AnswerId) // Foreign key in Upvote table
                   .OnDelete(DeleteBehavior.Cascade); // If an Answer is deleted, related Upvotes will also be deleted
        }
    }
}
