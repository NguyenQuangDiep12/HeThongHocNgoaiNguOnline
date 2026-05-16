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
    public class LessonProgressConfiguration : IEntityTypeConfiguration<LessonProgress>
    {
        public void Configure(EntityTypeBuilder<LessonProgress> builder)
        {
            builder.ToTable("lesson_progresses");
            builder.HasKey(lp => lp.Id);
            builder.Property(lp => lp.Id)
                .ValueGeneratedNever();

            builder.Property(lp => lp.CompletedPercent)
                .IsRequired()
                .HasColumnType("decimal(5,2)");
            builder.Property(lp => lp.IsCompleted)
                .IsRequired(false);
            builder.Property(lp => lp.CompletedAt)
                .IsRequired(false);
            builder.Property(lp => lp.UpdatedAt)
                .IsRequired(false);

            builder.HasOne(lp => lp.User)
                .WithMany(u => u.LessonsProgresses)
                .HasForeignKey(lp => lp.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(lp => lp.Lesson)
                .WithMany(l => l.LessonProgresses)
                .HasForeignKey(lp => lp.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_LessonProgress_Percent", "[Percent] >= 0 AND [Percent] <= 100"
                );
            });
        }
    }
}
