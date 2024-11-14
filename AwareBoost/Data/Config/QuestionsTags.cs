using AwareBoost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwareBoost.Data.Config
{
    public class QuestionsTagsConfiguration : IEntityTypeConfiguration<QuestionsTags>
    {
        public void Configure(EntityTypeBuilder<QuestionsTags> builder)
        {
            // Define composite primary key (QuestionId, TagId)
            builder.HasKey(qt => new { qt.QuestionId, qt.TagId });
        }
    }
}
