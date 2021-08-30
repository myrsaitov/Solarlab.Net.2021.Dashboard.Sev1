using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sev1.Advertisements.Infrastructure.DataAccess.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.UpdatedAt).IsRequired(false);
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();
            builder.Property(u => u.MiddleName)
                .HasMaxLength(100)
                .IsUnicode();
        }
    }
}