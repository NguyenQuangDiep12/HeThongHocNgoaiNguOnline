using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OELS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Repository.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payments");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.Transaction_Ref)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(p => p.PaymentMethod)
                .IsRequired()
                .HasConversion<int>();
            builder.Property(p => p.PaymentStatus)
                .IsRequired()
                .HasConversion<int>();
            builder.Property(p => p.PaidAt)
                .IsRequired();
            builder.Property(p => p.IsDeleted)
                .IsRequired(false);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Course)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CourseId) 
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(p => new { p.UserId, p.CourseId })
                .IsUnique();
        }
    }
}
