using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comments.Repository.Persistance.Configuration
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(ac => ac.ChatId);

            builder
                .HasMany(_ => _.Messages)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
