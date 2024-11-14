using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class BadgesConfiguration : IEntityTypeConfiguration<Badges>
    {
        public void Configure(EntityTypeBuilder<Badges> builder)
        {
            builder.HasKey(b => b.Id);  // Primary key for Badges

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            // Configure the many-to-many relationship using UserBadges as the join table
            builder.HasMany(b => b.Users)
                   .WithMany(u => u.Badges)
                   .UsingEntity<UserBadges>(
                       j => j.HasKey(ub => new { ub.AppUserId, ub.BadgeId }) // Composite primary key
                   );
        }
    }
}
