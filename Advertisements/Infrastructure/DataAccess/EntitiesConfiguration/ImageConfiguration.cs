using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sev1.Advertisements.Infrastructure.DataAccess.EntitiesConfiguration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CreatedAt).IsRequired();
        }
    }
}