using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class ViewsConfiguration : IEntityTypeConfiguration<Views>
    {
        public void Configure(EntityTypeBuilder<Views> builder)
        {
            // Primary Key configuration
            builder.HasKey(v => v.Id);

            // Relationship configuration for Views and Question
            builder.HasOne(v => v.Question) // Each View is for one Question
                   .WithMany(q => q.Views) // A Question can have many Views
                   .HasForeignKey(v => v.QuesitonId) // Foreign key in Views table
                   .OnDelete(DeleteBehavior.Cascade); // If a Question is deleted, its related Views will be deleted
        }
    }
}
