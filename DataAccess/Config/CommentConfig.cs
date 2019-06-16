using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Config
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Text)
                .HasMaxLength(1500)
                .IsRequired();

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
