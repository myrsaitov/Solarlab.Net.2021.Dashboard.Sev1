using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comments.Repository.Persistance.Configuration
{
    public class AdvertisementIdChatIdConfiguration : IEntityTypeConfiguration<AdvertisementIdChatId>
    {
        public void Configure(EntityTypeBuilder<AdvertisementIdChatId> builder)
        {
            builder.HasKey(ac => ac.AdvertisementId);
        }
    }
}
