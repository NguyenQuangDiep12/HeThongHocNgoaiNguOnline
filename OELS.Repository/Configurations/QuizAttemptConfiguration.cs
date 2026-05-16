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
    public class QuizAttemptConfiguration : IEntityTypeConfiguration<QuizAttempt>
    {
        public void Configure(EntityTypeBuilder<QuizAttempt> builder)
        {
            builder.ToTable("quiz_attempts");
            builder.HasKey(qa => qa.Id);
            builder.Property(qa => qa.Id)
                .ValueGeneratedNever();

            builder.Property(qa => qa.AttemptNumber)
                .IsRequired()
                .HasDefaultValue(1);
            builder.Property(qa => qa.Score)
                .IsRequired();
            builder.Property(qa => qa.IsPassed)
                .IsRequired();
            builder.Property(qa => qa.StartedAt)
                .IsRequired();
            builder.Property(qa => qa.SubmittedAt)
                .IsRequired(false);

            builder.HasOne(qa => qa.User)
                .WithMany(u => u.QuizAttempts)
                .HasForeignKey(qa => qa.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(qa => qa.Quiz)
                .WithMany(q => q.Answers)
                .HasForeignKey(qa => qa.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_QuizAttempt_Score", "[Score >= 0] AND [Score <= 100]");
            });
        }
    }
}
