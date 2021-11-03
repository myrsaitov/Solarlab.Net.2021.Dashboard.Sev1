using Sev1.UserFiles.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sev1.UserFiles.DataAccess.EntitiesConfiguration
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
                .WithMany(t => t.UserFiles)
                .UsingEntity(j => j.ToTable("TagAdvertisement"));
        }
    }
}