using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class AppUsersConfiguration : IEntityTypeConfiguration<AppUsers>
    {
        public void Configure(EntityTypeBuilder<AppUsers> builder)
        {
            // You can configure the CreatedAt property to be required or add any other constraints.
            builder.Property(u => u.CreatedAt)
                .IsRequired() // Ensure CreatedAt is not nullable
                .HasDefaultValueSql("GETUTCDATE()"); // Default value is current UTC time
        }
    }
}
