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
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("lessons");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .ValueGeneratedNever();

            builder.Property(l => l.Title)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(l => l.Content)
                .IsRequired()
                .HasColumnType("text");
            builder.Property(l => l.VideoUrl)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(l => l.DurationSecond)
                .IsRequired();
            builder.Property(l => l.SortOrder)
                .IsRequired(false);
            builder.Property(l => l.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasMany(l => l.LessonProgresses)
                .WithOne(lp => lp.Lesson)
                .HasForeignKey(lp => lp.LessonId);
            builder.HasMany(l => l.Quizzes)
                .WithOne(q => q.Lesson)
                .HasForeignKey(q => q.LessonId);
            builder.HasOne(l => l.Section)
                .WithMany(s => s.Lessons)
                .HasForeignKey(l => l.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
