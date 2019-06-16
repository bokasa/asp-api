using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
