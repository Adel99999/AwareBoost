using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class AnswersConfiguration : IEntityTypeConfiguration<Answers>
    {
        public void Configure(EntityTypeBuilder<Answers> builder)
        {
            // Configure the primary key
            builder.HasKey(a => a.Id);

            // Configure the Answer property
            builder.Property(a => a.Answer)
                .IsRequired()
                .HasMaxLength(1000); // Adjust the max length as needed

            // Configure the Created_At property
            builder.Property(a => a.Created_At)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Automatically sets the date/time

            // Configure the foreign key relationships
            builder.HasOne(a => a.User) // Each answer is related to a single user (AppUser)
                .WithMany(u => u.Answers) // A user can have many answers
                .HasForeignKey(a => a.AppUserId) // Foreign key property
                .OnDelete(DeleteBehavior.NoAction); // When the user is deleted, delete their answers

            builder.HasOne(a => a.Question) // Each answer is related to a single question
                .WithMany(q => q.Answers) // A question can have many answers
                .HasForeignKey(a => a.QuestionId) // Foreign key property
                .OnDelete(DeleteBehavior.NoAction); // When the question is deleted, delete the answers

            
        }
    }
}
