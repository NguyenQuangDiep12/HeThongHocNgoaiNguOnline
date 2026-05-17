using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OELS.Core.Models;
using OELS.Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedNever();

            builder.Property(u => u.FullName)
                .HasMaxLength(100)
                .HasDefaultValue(UtilsFunction.GenerateDefaultName()) // xu ly gia tri tinh , gia tri dong dung HasDefaultValueSql()
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Password_Hash)
                .HasMaxLength (255)
                .IsRequired();
            builder.Property(u => u.Role)
                .IsRequired()
                .HasConversion<int>();
            builder.Property(u => u.Avatar_Url)
                .HasMaxLength(255);
            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(u => u.IsDeleted)
                .IsRequired(false)
                .HasDefaultValue(false);
            builder.Property(x => x.UpdatedAt)
                .IsRequired(false);

            builder.HasMany(u => u.QuizAttempts)
                .WithOne(q => q.User)
                .HasForeignKey(q => q.UserId);

            builder.HasMany(u => u.Payments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            builder.HasMany(u => u.Enrollments)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
            builder.HasMany(u => u.Courses)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.CourseReviews)
                .WithOne(cr => cr.User)
                .HasForeignKey(cr => cr.UserId);
            builder.HasMany(u => u.Certificates)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
