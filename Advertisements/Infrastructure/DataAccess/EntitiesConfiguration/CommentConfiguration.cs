using System;
using Sev1.Advertisements.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sev1.Advertisements.Infrastructure.DataAccess.EntitiesConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(com => com.Id);
            builder.Property(com => com.CreatedAt).IsRequired();
            builder.Property(com => com.UpdatedAt).IsRequired(false);
        }
    }
}