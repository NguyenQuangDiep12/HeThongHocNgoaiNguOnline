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
    public class CourseReviewConfiguration : IEntityTypeConfiguration<CourseReview>
    {
        public void Configure(EntityTypeBuilder<CourseReview> builder)
        {
            builder.ToTable("course_reviews");
            builder.HasKey(cr => cr.Id);
            builder.Property(cr => cr.Id)
                .ValueGeneratedNever();

            builder.Property(cr => cr.Rating)
                .IsRequired()
                .HasColumnType("decimal(2,1)");
            builder.Property(cr => cr.Comment)
                .IsRequired(false)
                .HasMaxLength(255);
            builder.Property(cr => cr.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(cr => cr.UpdatedAt)
                .IsRequired(false);

            builder.HasOne(cr => cr.User)
                .WithMany(u => u.CourseReviews)
                .HasForeignKey(cr => cr.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(cr => cr.Course)
                .WithMany(c => c.CourseReviews)
                .HasForeignKey(cr => cr.CourseId)
                .OnDelete(DeleteBehavior.Restrict); // ngan chan multiple cascade path
        }
    }
}
