using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class UserBadgesConfiguration : IEntityTypeConfiguration<UserBadges>
    {
        public void Configure(EntityTypeBuilder<UserBadges> builder)
        {
            // Primary Key configuration
            builder.HasKey(ub => new { ub.AppUserId, ub.BadgeId });

         
        }
    }
}
