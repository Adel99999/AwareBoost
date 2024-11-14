using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);  // Set primary key

            builder.Property(c => c.Name)
                   .IsRequired()  // Make Name required
                   .HasMaxLength(100);  // Set maximum length for Name
        }
    }

}
