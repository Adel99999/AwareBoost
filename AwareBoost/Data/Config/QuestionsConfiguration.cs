using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class QuestionsConfiguration : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            // Primary Key configuration
            builder.HasKey(q => q.Id);

            // Relationship configuration
            builder.HasOne(q => q.User) // Question has one AppUser (the creator)
                   .WithMany(u => u.Questions) // An AppUser can have many Questions
                   .HasForeignKey(q => q.AppUserId) // Foreign key is AppUserId
                   .OnDelete(DeleteBehavior.Cascade); // If the user is deleted, delete related questions

            builder.HasOne(q => q.Category) // Question belongs to one Category
                   .WithMany(c => c.Questions) // A Category can have many Questions
                   .HasForeignKey(q => q.CategoryId) // Foreign key is CategoryId
                   .OnDelete(DeleteBehavior.SetNull); // If Category is deleted, set CategoryId to null
            builder.HasMany(q => q.Tags)
                  .WithMany(t => t.Questions)
                  .UsingEntity(j => j.ToTable("QuestionTags")); // This is the join table name


        }
    }
}
