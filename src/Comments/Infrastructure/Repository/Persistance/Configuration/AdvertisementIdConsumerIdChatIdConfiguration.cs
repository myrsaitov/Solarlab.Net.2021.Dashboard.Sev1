using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comments.Repository.Persistance.Configuration
{
    public class AdvertisementIdConsumerIdChatIdConfiguration : IEntityTypeConfiguration<AdvertisementIdConsumerIdChatId>
    {
        public void Configure(EntityTypeBuilder<AdvertisementIdConsumerIdChatId> builder)
        {
            builder.HasKey(acc => new { acc.AdvertisementId, acc.ConsumerId });
        }
    }
}
