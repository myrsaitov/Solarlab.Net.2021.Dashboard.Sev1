using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sev1.Advertisements.DataAccess.EntitiesConfiguration
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(adv => adv.Id);
            builder.Property(adv => adv.CreatedAt).IsRequired();
            builder.Property(adv => adv.UpdatedAt).IsRequired(false);
            builder.Property(adv => adv.Price).HasColumnType("money");
            builder.HasMany(adv => adv.Tags)
                .WithMany(t => t.Advertisements)
                .UsingEntity(j => j.ToTable("TagAdvertisement"));
            builder.HasOne(adv => adv.Region)
                .WithMany(r => r.Advertisements);
        }
    }
}