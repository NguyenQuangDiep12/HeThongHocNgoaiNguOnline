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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("courses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedNever();

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(c => c.Level)
                .IsRequired()
                .HasConversion<int>();
            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(c => c.Thumbnail_Url)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(c => c.IsPublished)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(c => c.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasMany(c => c.CourseReviews)
                .WithOne(cr => cr.Course)
                .HasForeignKey(cr => cr.CourseId);
            builder.HasMany(c => c.Certificates)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);
            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);
            builder.HasMany(c => c.Payments)
                .WithOne(p => p.Course)
                .HasForeignKey(p => p.CourseId);
            builder.HasMany(c => c.Sections)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);
            builder.HasMany(c => c.Certificates)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
