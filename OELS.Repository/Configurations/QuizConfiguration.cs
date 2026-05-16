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
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable("quizzes");
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id)
                .ValueGeneratedNever();

            builder.Property(q => q.Title)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(q => q.Description)
                .IsRequired()
                .HasColumnType("text");
            builder.Property(q => q.PassScore)
                .IsRequired()
                .HasDefaultValue(70);
            builder.Property(q => q.LimitTimeSec)
                .IsRequired(false);
            builder.Property(q => q.MaxAttempt)
                .IsRequired(false);

            builder.HasOne(q => q.Lesson)
                .WithMany(l => l.Quizzes)
                .HasForeignKey(q => q.LessonId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(q => q.Answers)
                .WithOne(a => a.Quiz)
                .HasForeignKey(a => a.QuizId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(q => q.Questions)
                .WithOne(qq => qq.Quiz)
                .HasForeignKey(qq => qq.QuizId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
