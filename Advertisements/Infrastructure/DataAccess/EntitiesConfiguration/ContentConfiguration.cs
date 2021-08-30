using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sev1.Advertisements.Infrastructure.DataAccess.EntitiesConfiguration
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(con => con.Id);
            builder.Property(con => con.CreatedAt).IsRequired();
            builder.Property(con => con.UpdatedAt).IsRequired(false);
            builder.Property(con => con.Price).HasColumnType("money");
            builder.HasMany(con => con.Tags)
                .WithMany(t => t.Advertisements)
                .UsingEntity(j => j.ToTable("TagAdvertisement"));
        }
    }
}