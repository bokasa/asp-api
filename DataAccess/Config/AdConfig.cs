using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Config
{
    public class AdConfig : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.Property(a => a.Title)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.Body)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(a => a.Price)
                .IsRequired();

            builder.Property(a => a.IsShipping)
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
