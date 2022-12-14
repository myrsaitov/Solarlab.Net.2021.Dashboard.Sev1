using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sev1.Accounts.Domain;

namespace Sev1.Accounts.DataAccess.EntitiesConfiguration
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