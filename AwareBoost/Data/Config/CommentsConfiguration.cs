using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            // Define Primary Key
            builder.HasKey(c => c.Id);

            // Define properties
            builder.Property(c => c.Comment)
                   .IsRequired()  // Make sure the comment is required
                   .HasMaxLength(500);  // Set a max length for the comment, adjust as needed

            builder.Property(c => c.Created_At)
                   .IsRequired();  // Created_At should be required

            // Define the relationship between Comments and AppUsers
            builder.HasOne(c => c.User)
                   .WithMany(u => u.Comments)
                   .HasForeignKey(c => c.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade);  // Optional: Define delete behavior (Cascade means deleting a user deletes their comments)

            // Define the relationship between Comments and Answers
            builder.HasOne(c => c.Answer)
                   .WithMany(a => a.Comments)
                   .HasForeignKey(c => c.AnswerId)
                   .OnDelete(DeleteBehavior.Cascade);  // Optional: Define delete behavior (Cascade means deleting an answer deletes its comments)
        }
    }
}
