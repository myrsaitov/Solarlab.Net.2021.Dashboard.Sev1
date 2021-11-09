using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comments.Repository.Persistance.Configuration
{
    public class UserRatingConfiguration : IEntityTypeConfiguration<UserRating>
    {
        public void Configure(EntityTypeBuilder<UserRating> builder)
        {
            builder.HasKey(c => c.UserId);
        }
    }
}
