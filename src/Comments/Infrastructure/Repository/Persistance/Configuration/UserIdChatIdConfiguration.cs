using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comments.Repository.Persistance.Configuration
{
    public class UserIdChatIdConfiguration : IEntityTypeConfiguration<UserIdChatId>
    {
        public void Configure(EntityTypeBuilder<UserIdChatId> builder)
        {
            builder.HasKey(ac => ac.ChatId);
        }
    }
}
