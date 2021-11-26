using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comments.Repository.Persistance.Configuration
{
    public class CommentReviewConfiguration : IEntityTypeConfiguration<CommentReview>
    {
        public void Configure(EntityTypeBuilder<CommentReview> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}