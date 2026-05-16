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
    public class QuizAnswerConfiguration : IEntityTypeConfiguration<QuizAnswer>
    {
        public void Configure(EntityTypeBuilder<QuizAnswer> builder)
        {
            builder.ToTable("quiz_answers");
            builder.HasKey(qa => qa.Id);
            builder.Property(qa => qa.Id)
                .ValueGeneratedNever();

            builder.Property(qa => qa.AnswerText)
                .IsRequired(false)
                .HasColumnType("text");
            builder.Property(qa => qa.IsCorrect)
                .IsRequired();
            builder.Property(qa => qa.PointEarned)
                .IsRequired();

            builder.HasOne(qa => qa.Attempt)
                .WithMany(a => a.Answers)
                .HasForeignKey(qa => qa.AttemptId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(qa => qa.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(qa => qa.QuestionId)
                .OnDelete(DeleteBehavior.Restrict); // fix: multiple cascade path
            builder.HasOne(qa => qa.SelectedOption) // find at: https://www.mssqltips.com/sqlservertip/2733/solving-the-sql-server-multiple-cascade-path-issue-with-a-trigger/
                .WithMany(so => so.Answers)
                .HasForeignKey(qa => qa.SelectedOptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
