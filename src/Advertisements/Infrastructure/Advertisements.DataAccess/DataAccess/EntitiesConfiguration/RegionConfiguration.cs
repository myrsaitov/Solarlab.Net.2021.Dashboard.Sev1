using System;
using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sev1.Advertisements.DataAccess.EntitiesConfiguration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        // Начальное сидирование категорий в базу
        private Region[] regions = new Region[]
        {
            new Region
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Севастполь",
                Count = 0,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            },
            new Region
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Крым",
                Count = 0,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            }
        };
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.HasData(regions);
        }
    }
}