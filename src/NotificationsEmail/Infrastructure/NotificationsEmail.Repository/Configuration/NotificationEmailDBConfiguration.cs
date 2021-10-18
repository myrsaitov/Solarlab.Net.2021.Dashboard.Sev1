using NotificationsEmail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NotificationsEmail.Repository.Configuration
{
    public class NotificationEmailDBConfiguration : IEntityTypeConfiguration<Letter>
    {
        public void Configure(EntityTypeBuilder<Letter> builder)
        {
            builder.ToTable(nameof(Letter));

            builder.HasKey(c => c.LetterId);

            builder.Property(c => c.LetterId)
                .ValueGeneratedOnAdd();
        }
    }
}
